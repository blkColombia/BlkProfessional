using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCL
{
     public class Weekly
    {
        #region Propiedades

        public Weekly() { }

        public Weekly(Int64? _mintWeeklyId,
                        String _mstrTerminal,
                        String _mstrLocationCode,
                        String _mstrTipoLiquidacion,
                        String _mstrClase,
                        String _mstrMes,
                        String _mstrCliente,
                        String _mstrSubCliente,
                        String _mstrTipoCuenta,
                        String _mstrCuenta,
                        String _mstrSubCuenta,
                        String _mstrObservacion,
                        String _mstrPresupuestoMes,
                        String _mstrTotalEjecutadoMes,
                        String _mstrUsuarioCreacion,
                        String _mstrFechaInicio,
                        String _mstrFechaFin
                        )
        {
            mintWeeklyId = _mintWeeklyId;
            mstrTerminal = _mstrTerminal;
            mstrLocationCode = _mstrLocationCode;
            mstrTipoLiquidacion = _mstrTipoLiquidacion;
            mstrClase = _mstrClase;
            mstrMes = _mstrMes;
            mstrCliente = _mstrCliente;
            mstrSubCliente = _mstrSubCliente;
            mstrTipoCuenta = _mstrTipoCuenta;
            mstrCuenta = _mstrCuenta;
            mstrSubCuenta = _mstrSubCuenta;
            mstrObservacion = _mstrObservacion;
            mstrPresupuestoMes = _mstrPresupuestoMes;
            mstrTotalEjecutadoMes = _mstrTotalEjecutadoMes;
            mstrUsuarioCreacion = _mstrUsuarioCreacion;
            mstrFechaInicio = _mstrFechaInicio;
            mstrFechaFin = _mstrFechaFin;
        }

        public Weekly(IDataRecord obj)
        {
            mintWeeklyId = Convert.ToInt64(obj["IdWeekley"]);
            mstrTerminal = Convert.ToString(obj["Terminal"]);
            mstrLocationCode = Convert.ToString(obj["LocationCode"]);
            mstrTipoLiquidacion = Convert.ToString(obj["TipoLiquidacion"]);
            mstrClase = Convert.ToString(obj["Clase"]);
            mstrYear = Convert.ToString(obj["Year"]);
            mstrMes = Convert.ToString(obj["Mes"]);
            mstrCliente = Convert.ToString(obj["Cliente"]);
            mstrDesCliente = Convert.ToString(obj["DescCliente"]);
            mstrSubCliente = Convert.ToString(obj["SubCliente"]);
            mstrTipoCuenta = Convert.ToString(obj["TipoCuenta"]);
            mstrCuenta = Convert.ToString(obj["Cuenta"]);
            mstrSubCuenta = Convert.ToString(obj["SubCuenta"]);
            mstrObservacion = Convert.ToString(obj["Observacion"]);
            mstrPresupuestoMes = Convert.ToString(obj["PresupuestoMes"]);
            mstrTotalEjecutadoMes = Convert.ToString(obj["TotalEjecutadoMes"]);
            mstrUsuarioCreacion = Convert.ToString(obj["UsuarioCreacion"]);
            mstrFechaInicio = Convert.ToString(obj["FechaInicio"]);
            mstrFechaFin = Convert.ToString(obj["FechaFin"]);
        }

        public Weekly(DataRow obj)
        {
            mintWeeklyId = Convert.ToInt64(obj["IdWeekley"]);
            mstrTerminal = Convert.ToString(obj["Terminal"]);
            mstrLocationCode = Convert.ToString(obj["LocationCode"]);
            mstrTipoLiquidacion = Convert.ToString(obj["TipoLiquidacion"]);
            mstrClase = Convert.ToString(obj["Clase"]);
            mstrYear = Convert.ToString(obj["Year"]);
            mstrMes = Convert.ToString(obj["Mes"]);
            mstrCliente = Convert.ToString(obj["Cliente"]);
            mstrDesCliente = Convert.ToString(obj["DescCliente"]);
            mstrSubCliente = Convert.ToString(obj["SubCliente"]);
            mstrTipoCuenta = Convert.ToString(obj["TipoCuenta"]);
            mstrCuenta = Convert.ToString(obj["Cuenta"]);
            mstrSubCuenta = Convert.ToString(obj["SubCuenta"]);
            mstrObservacion = Convert.ToString(obj["Observacion"]);
            mstrPresupuestoMes = Convert.ToString(obj["PresupuestoMes"]);
            mstrTotalEjecutadoMes = Convert.ToString(obj["TotalEjecutadoMes"]);
            mstrUsuarioCreacion = Convert.ToString(obj["UsuarioCreacion"]);
            mstrFechaInicio = Convert.ToString(obj["FechaInicio"]);
            mstrFechaFin = Convert.ToString(obj["FechaFin"]);
        }

        #endregion

        #region Constructores

        Int64? mintWeeklyId = null;
        public Int64? WeeklyId
        {
            get { return mintWeeklyId; }
            set { mintWeeklyId = value; }
        }

  
        String mstrTerminal = null;
        public String Terminal
        {
            get { return mstrTerminal; }
            set { mstrTerminal = value; }
        }

        String mstrLocationCode = null;
        public String LocationCode
        {
            get { return mstrLocationCode; }
            set { mstrLocationCode = value; }
        }

        String mstrTipoLiquidacion = null;
        public String TipoLiquidacion
        {
            get { return mstrTipoLiquidacion; }
            set { mstrTipoLiquidacion = value; }
        }

 

        String mstrClase = null;
        public String Clase
        {
            get { return mstrClase; }
            set { mstrClase = value; }
        }

        String mstrYear = null;
        public String Year
        {
            get { return mstrYear; }
            set { mstrYear = value; }
        }

        String mstrMes = null;
        public String Mes
        {
            get { return mstrMes; }
            set { mstrMes = value; }
        }

        String mstrCliente = null;
        public String Cliente
        {
            get { return mstrCliente; }
            set { mstrCliente = value; }
        }

        String mstrDesCliente = null;
        public String DesCliente
        {
            get { return mstrDesCliente; }
            set { mstrDesCliente = value; }
        }

        String mstrSubCliente = null;
        public String SubCliente
        {
            get { return mstrSubCliente; }
            set { mstrSubCliente = value; }
        }

        String mstrTipoCuenta = null;
        public String TipoCuenta
        {
            get { return mstrTipoCuenta; }
            set { mstrTipoCuenta = value; }
        }

        String mstrCuenta = null;
        public String Cuenta
        {
            get { return mstrCuenta; }
            set { mstrCuenta = value; }
        }

        String mstrSubCuenta = null;
        public String SubCuenta
        {
            get { return mstrSubCuenta; }
            set { mstrSubCuenta = value; }
        }

        String mstrObservacion = null;
        public String Observacion
        {
            get { return mstrObservacion; }
            set { mstrObservacion = value; }
        }

        String mstrPresupuestoMes = null;
        public String PresupuestoMes
        {
            get { return mstrPresupuestoMes; }
            set { mstrPresupuestoMes = value; }
        }

        String mstrTotalEjecutadoMes = null;
        public String TotalEjecutadoMes
        {
            get { return mstrTotalEjecutadoMes; }
            set { mstrTotalEjecutadoMes = value; }
        }

        String mstrUsuarioCreacion = null;
        public String UsuarioCreacion
        {
            get { return mstrUsuarioCreacion; }
            set { mstrUsuarioCreacion = value; }
        }

        String mstrFechaInicio = null;
        public String FechaInicio
        {
            get { return mstrFechaInicio; }
            set { mstrFechaInicio = value; }
        }

        String mstrFechaFin = null;
        public String FechaFin
        {
            get { return mstrFechaFin; }
            set { mstrFechaFin = value; }
        }

        #endregion
    }
}
