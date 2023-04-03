namespace Aplicacion.Enums
{
    public enum Roles
    {
        Root,
        SuperAdmin,
        Admin,
        Basic,
        Cliente
    }

    public enum ClasificadorTipo
    {
        TipoGenero = 6,
        TipoSubsidio = 2

    }

    public enum TipoPlanilla
    {
        NORMAL = 301,
        MIGRACION = 303,
        RETROACTIVO = 323,
        PLANILLA_NEGATIVA = 513
    }

    public enum Estadoplanilla
    {
        REGISTRADO = 26,
        APROBADO = 27,
        ANULADO = 61,
        PAGADO = 502
    }

    public enum TipoUbiacion
    {
        Departamento = 47
    }

    public enum EstadoRegistroTitualar
    {
        APROBADO = 72,
        REGISTRADO = 38
    }

    public enum ClasificadorRegistrado
    {
        IdgenClasificador = 38
    }

    public enum ClasificadorTipoEstado
    {
        IdgenClasificadortipo = 18
    }

    public enum ClasificadorTipoSubsidio
    {
        IdgenClasificadortipo = 2
    }

    public enum ClasificadorTipoSubPrenatalLactan
    {
        //valor = { 64, 5, 63, 4 }
    }

    //TIPO 12
    public enum EstadosPlanificacion
    {
        REGISTRADO = 21,
        APROBADO = 22,
        LIBERADO = 75
    }

    public enum EstadoPlanillaDetalle
    { 
        HABILITADO = 66,
        INHABILITADO = 67
    }


    public enum IdEstadoExtractoUninet
    {
        REGISTRADO = 505,
        VERIFICADO = 506,
        POR_VERIFICAR = 507,
        PAGADO = 510
    }

    public enum IdcTipoMoneda
    { 
        BOLIVIANOS = 508,
        DOLARES = 509
    }

    public enum IdcEstadoFactura
    { 
        REGISTRADO = 35,
        FACTURADO = 36,
        ANULADO = 37
    }
}
