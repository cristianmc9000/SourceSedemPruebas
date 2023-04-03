using Aplicacion.DTOs.Sucursal;
using Infraestructura.Abstract;
using Infraestructura.Component;
using Infraestructura.Models;
using Microsoft.JSInterop;
using Server.Pages.Pages.Authentication;
using Syncfusion.Blazor.Diagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using State = Infraestructura.Abstract.State;

namespace Server.Pages.Sucursal
{
    public partial class Sucursal
    {
        private static List<FcSucursalDto> sucursal { get; set; }
        public FcSucursalDto _SucursalNuevo = new FcSucursalDto();


        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;


        protected override async void OnInitialized()
        {
            await GetSucursal();


        }

        protected async Task GetSucursal()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<FcSucursalDto>>("FcSucursal");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                sucursal = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        //////EDITAR 

        protected void ShowBtnEditSave(int idpruebas)
        {
            var vpruebas = sucursal.First(f => f.IdfcSucursal == idpruebas);
            vpruebas.VerDetalle = !vpruebas.VerDetalle;
        }


        protected async void ShowBtnEditSave(FcSucursalDto dato)
        {
            await editarpruebas(dato);


        }
        protected async Task editarpruebas(FcSucursalDto dato)
        {
            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("FcSucursal", dato, dato.IdfcSucursal);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    dato.IdfcSucursal = _update.Data;
                    dato.VerDetalle = !dato.VerDetalle;
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

        protected async void ShowBtnEditSaveCancel(int IdfcSucursal, FcSucursalDto dato)
        {
            var vafiliacion = sucursal.First(f => f.IdfcSucursal == IdfcSucursal);
            vafiliacion.VerDetalle = !vafiliacion.VerDetalle;
        }

        private async Task SucursalNuevo()
        {
            await Save();

        }
        protected async Task Save()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("FcSucursal", new { sucursal = _SucursalNuevo });
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
                else
                {
                    _MessageShow("Se registro Correctamente..", State.Success);
                    await GetSucursal();
                }



            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }

        public async Task Eliminar(int idpruebas)
        {
            await _MessageConfirm("esta seguro de eliminar el registro...?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("FcSucursal", (int)idpruebas);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    //await getlistestractouninet();
                    StateHasChanged();
                    await GetSucursal();
                }
            });
        }

    }



}
