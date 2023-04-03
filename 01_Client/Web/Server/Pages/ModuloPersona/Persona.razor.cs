//using Aplicacion.DTOs.ModuloPersona;
using Infraestructura.Models.ModuloPersona;
using Infraestructura.Models.ModuloEmpresa;
using Infraestructura.Models.ModuloPasatiempo;
using Infraestructura.Models.ModuloPerpas;
using Infraestructura.Abstract;
using Infraestructura.Component;
using Infraestructura.Models;
using Microsoft.AspNetCore.Components.Forms;

using Microsoft.JSInterop;
using Server.Pages.Pages.Authentication;
using Syncfusion.Blazor.Diagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Components.Forms;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
using State = Infraestructura.Abstract.State;
using FluentValidation;
using System.Text.Json;
using System.Reflection;
//using Aplicacion.DTOs.ModuloPerpas;

namespace Server.Pages.ModuloPersona
{
    public partial class Persona
    {
        private static List<PruebaEmpresaDto> listaempresas { get; set; }
        private static List<PruebaPersonaDto> listapersonas { get; set; }
        private static List<PruebaPasatiempoDto> listapasatiempos { get; set; }
        private static List<PruebaPerpasDto> listaperpas { get; set; }
        public PruebaPersonaDto _PersonaNueva = new PruebaPersonaDto();

        private string fecha;
        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;
        public string searchText = "";

        private bool FilterFunc1(PruebaPersonaDto element) => FilterCycleCheck(element, searchText);

        protected override async void OnInitialized()
        {
            await onTablaAsyncEmpresa();
            await onTablaAsyncPersona();
            await onTablaAsyncPasatiempo();
            await onTablaAsyncPerpas();
        }

		private bool FilterCycleCheck(PruebaPersonaDto item, string searchString)
		{
            string a = Convert.ToString(item.IdPersona);
            if(string.IsNullOrWhiteSpace(searchText))
                return true;
            if(item.Nombres.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if(item.Paterno.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if(item.Materno.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
		}

		protected async Task onTablaAsyncPersona()
		{
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<PruebaPersonaDto>>("Persona");
                _Loading.Hide();
                if(_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                else
                {
                    listapersonas = _result.Data;
                }
            }
            catch(Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
		}

        protected async Task SavePersona()
        {
            //_MessageShow(_PersonaNueva.Nombres + " " + _PersonaNueva.Paterno + " " + _PersonaNueva.Materno + " " + fecha + " " + _PersonaNueva.LugarNacimiento + " " + _PersonaNueva.IdEmpresa, State.Success);
            //var selectedPasatiempos = listapasatiempos.Where(p => _PersonaNueva.Pasatiempos.Contains(p.Nombre)).Select(p => p.IdPasatiempo);

            //_MessageShow(selectedPasatiempos, State.Success);
            //return;
            if (string.IsNullOrWhiteSpace(fecha))
            {
                _MessageShow("<b>El campo fecha de nacimiento es obligatorio.</b>", State.Warning);
                return;
            }

            try
            {
                _Loading.Show();
                _PersonaNueva.FechaNacimiento = fecha;
                
                var vrespost = await _Rest.PostAsync<int>("Persona", new { Persona = _PersonaNueva });
                
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State != State.Success)
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    return;
                }


                foreach (var pasatiempo in listapasatiempos)
                {
                    if (_PersonaNueva.Pasatiempos.Contains(pasatiempo.Nombre))
                    {
                        var personaPasatiempo = new PruebaPerpasDto
                        {
                            IdPersona = int.Parse(vrespost.Data.ToString()),
                            IdPasatiempo = pasatiempo.IdPasatiempo
                        };
                        var result = await _Rest.PostAsync<int>("Perpas", new { Perpas = personaPasatiempo });
                    }
                }

                _Loading.Hide();
                //await onTablaAsyncPasatiempo();
                await onTablaAsyncPerpas();
                await onTablaAsyncPersona();
                _MessageShow("<b>Usuario agregado correctamente</b>", State.Success);
                //_MessageShow(vrespost.Data.ToString(), State.Success);
            }
            catch (Exception e)
            {
                _Loading.Hide();
                
                //_MessageShow("<b>Debe seleccionar una fecha de nacimiento válida.</b>", State.Warning);
                //Console.WriteLine(e.Message, State.Error);
                _MessageShow(e.Message, State.Error); //AQUI SE DESPLIEGA EL MENSAJE DE ERROR
            }
            
        }

        protected async Task EditPersona(PruebaPersonaDto personaDto)
        {
            //_MessageShow((personaDto.FechaNacimiento+"-/////-"+personaDto.Nombres+" "+personaDto.Paterno + " " + personaDto.Materno + " " + personaDto.IdEmpresa.ToString()) ,State.Success);
            if (string.IsNullOrWhiteSpace(personaDto.Nombres))
            {
                _MessageShow("<b>El campo NOMBRE es obligatorio.</b>", State.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(personaDto.Paterno))
            {
                _MessageShow("<b>El campo Ap. Paterno es obligatorio.</b>", State.Warning);
                return;
            }
            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("Persona", personaDto, personaDto.IdPersona);
                if(_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    personaDto.IdPersona = _update.Data;
                }
                else
                {
                    _MessageShow(_update.Message, _update.State);
                }
            }
            catch (Exception e)
            {
                _DialogShow(e.Message, State.Error);
            }
            finally
            {
                _Loading.Hide();
            }
        }

        protected async Task ShowBtnEliminaPersona(int idpersona)
        {
            await _MessageConfirm("¿Está seguro de eliminar el registro?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("Persona", idpersona);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    await onTablaAsyncPersona();
                    StateHasChanged();
                }
            });
            
        }

        private async Task OnValidPersonaNuevo(EditContext context)
        {
            await SavePersona();
        }
        protected void ShowBtnEdit(int v_idpersona)
        {
            var vpersona = listapersonas.First(f => f.IdPersona == v_idpersona);
            vpersona.VerDetalle = !vpersona.VerDetalle;

        }
        protected async void ShowBtnEditCancelPersona(int v_idpersona)
        {
            var vempresa = listapersonas.First(f => f.IdPersona == v_idpersona);
            vempresa.VerDetalle = !vempresa.VerDetalle; 
        }


        //public void OnGet()
        //{
        //}
        protected async Task onTablaAsyncEmpresa()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<PruebaEmpresaDto>>("Empresa");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                else
                {
                    listaempresas = _result.Data;
                }
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        protected async Task onTablaAsyncPasatiempo()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<PruebaPasatiempoDto>>("Pasatiempo");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                else
                {
                    listapasatiempos = _result.Data;
                }
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
        protected async Task onTablaAsyncPerpas()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<PruebaPerpasDto>>("Perpas");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                else
                {
                    listaperpas = _result.Data;
                }
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
    }
}
