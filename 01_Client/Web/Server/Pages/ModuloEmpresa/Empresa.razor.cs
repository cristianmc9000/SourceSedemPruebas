//using Aplicacion.DTOs.ModuloEmpresa;
using Infraestructura.Models.ModuloEmpresa;
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



namespace Server.Pages.ModuloEmpresa
{
    public partial class Empresa
    {
        private static List<PruebaEmpresaDto> listaempresas { get; set; }
        public PruebaEmpresaDto _EmpresaNueva = new PruebaEmpresaDto();

        //private string fecha;
        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;
        public string searchText = "";

        private bool FilterFunc1(PruebaEmpresaDto element) => FilterCycleCheck(element, searchText);

        protected override async void OnInitialized()
        {
            await onTablaAsyncEmpresa();
        }



        private bool FilterCycleCheck(PruebaEmpresaDto item, string searchString)
        {
            string a = Convert.ToString(item.IdEmpresa);
            if (string.IsNullOrWhiteSpace(searchText))
                return true;
            if (item.Nombre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (item.Departamento.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

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

        protected async Task SaveEmpresa()
        {
            try
            {
                _Loading.Show();
                //_EmpresaNueva.FechaNacimiento = fecha;
                var vrespost = await _Rest.PostAsync<int>("Empresa", new { Empresa = _EmpresaNueva });
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State != State.Success)
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    return;
                }
                await onTablaAsyncEmpresa();
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }

        protected async Task EditEmpresa(PruebaEmpresaDto empresaDto)
        {
            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("Empresa", empresaDto, empresaDto.IdEmpresa);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    empresaDto.IdEmpresa = _update.Data;
                    empresaDto.VerDetalle = !empresaDto.VerDetalle;
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

        protected async Task ShowBtnEliminaEmpresa(int idempresa)
        {
            await _MessageConfirm("¿Está seguro de eliminar el registro?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("Empresa", idempresa);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    await onTablaAsyncEmpresa();
                    StateHasChanged();
                }
            });

        }

        private async Task OnValidEmpresaNuevo(EditContext context)
        {
            //Console.WriteLine(_EmpresaNueva.Departamento);
            await SaveEmpresa();
        }
        protected void ShowBtnEdit(int v_idempresa)
        {
            var vempresa = listaempresas.First(f => f.IdEmpresa == v_idempresa);
            vempresa.VerDetalle = !vempresa.VerDetalle;

        }
        protected async void ShowBtnEditCancelEmpresa(int v_idempresa)
        {
            var vempresa = listaempresas.First(f => f.IdEmpresa == v_idempresa);
            vempresa.VerDetalle = !vempresa.VerDetalle;
        }


        //public void OnGet()
        //{
        //}
    }
}
