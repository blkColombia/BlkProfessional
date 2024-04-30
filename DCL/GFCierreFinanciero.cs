using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCL
{
    public class GFCierreFinanciero
    {
        #region Propiedades

        public GFCierreFinanciero() { }

        public GFCierreFinanciero(Int64? _mintIdCierre,                        
                        String _mstrFechaInicial,
                        String _mstrFechaFinal,
                        String _mstrTerminal,
                        Int64? _mintEstado,
                        String _mstrFechaCreacion,
                        String _mstrUsuarioCreacion,
                        String _mstrFechaActualizacion,
                        String _mstrUsuarioActualizacion,
                        String _mstrFechaCierre,
                        String _mstrUsuarioCierre
                        )
        {
            mintIdCierre = _mintIdCierre;
            mstrFechaInicial = _mstrFechaInicial;
            mstrFechaFinal = _mstrFechaFinal;
            mstrTerminal = _mstrTerminal;
            mintEstado = _mintEstado;
            mstrFechaCreacion = _mstrFechaCreacion;
            mstrUsuarioCreacion = _mstrUsuarioCreacion;
            mstrFechaActualizacion = _mstrFechaActualizacion;
            mstrUsuarioActualizacion = _mstrUsuarioActualizacion;
            mstrFechaCierre = _mstrFechaCierre;
            mstrUsuarioCierre = _mstrUsuarioCierre;
        }

        public GFCierreFinanciero(IDataRecord obj)
        {
            mintIdCierre = Convert.ToInt64(obj["IdCierre"]);
            mstrFechaInicial = Convert.ToString(obj["FechaInicial"]);
            mstrFechaFinal = Convert.ToString(obj["FechaFinal"]);
            mstrTerminal = Convert.ToString(obj["Terminal"]);
            mintEstado = Convert.ToInt64(obj["Estado"]);
            mstrFechaCreacion = Convert.ToString(obj["FechaCreacion"]);
            mstrUsuarioCreacion = Convert.ToString(obj["UsuarioCreacion"]);
            mstrFechaActualizacion = Convert.ToString(obj["FechaActualizacion"]);
            mstrUsuarioActualizacion = Convert.ToString(obj["UsuarioActualizacion"]);
            mstrFechaCierre = Convert.ToString(obj["FechaCierre"]);
            mstrUsuarioCierre = Convert.ToString(obj["UsuarioCierre"]);
        }

        public GFCierreFinanciero(DataRow obj)
        {
            mintIdCierre = Convert.ToInt64(obj["IdCierre"]);
            mstrFechaInicial = Convert.ToString(obj["FechaInicial"]);
            mstrFechaFinal = Convert.ToString(obj["FechaFinal"]);
            mstrTerminal = Convert.ToString(obj["Terminal"]);
            mintEstado = Convert.ToInt64(obj["Estado"]);
            mstrFechaCreacion = Convert.ToString(obj["FechaCreacion"]);
            mstrUsuarioCreacion = Convert.ToString(obj["UsuarioCreacion"]);
            mstrFechaActualizacion = Convert.ToString(obj["FechaActualizacion"]);
            mstrUsuarioActualizacion = Convert.ToString(obj["UsuarioActualizacion"]);
            mstrFechaCierre = Convert.ToString(obj["FechaCierre"]);
            mstrUsuarioCierre = Convert.ToString(obj["UsuarioCierre"]);
        }

        #endregion

        #region Constructores

        Int64? mintIdCierre = null;
        public Int64? IdCierre
        {
            get { return mintIdCierre; }
            set { mintIdCierre = value; }
        }


        String mstrFechaInicial = null;
        public String FechaInicial
        {
            get { return mstrFechaInicial; }
            set { mstrFechaInicial = value; }
        }

        String mstrFechaFinal = null;
        public String FechaFinal
        {
            get { return mstrFechaFinal; }
            set { mstrFechaFinal = value; }
        }

        String mstrTerminal = null;
        public String Terminal
        {
            get { return mstrTerminal; }
            set { mstrTerminal = value; }
        }

        Int64? mintEstado = null;
        public Int64? Estado
        {
            get { return mintEstado; }
            set { mintEstado = value; }
        }

        String mstrFechaCreacion = null;
        public String FechaCreacion
        {
            get { return mstrFechaCreacion; }
            set { mstrFechaCreacion = value; }
        }

        String mstrUsuarioCreacion = null;
        public String UsuarioCreacion
        {
            get { return mstrUsuarioCreacion; }
            set { mstrUsuarioCreacion = value; }
        }


        String mstrFechaActualizacion = null;
        public String FechaActualizacion
        {
            get { return mstrFechaActualizacion; }
            set { mstrFechaActualizacion = value; }
        }

        String mstrUsuarioActualizacion = null;
        public String UsuarioActualizacion
        {
            get { return mstrUsuarioActualizacion; }
            set { mstrUsuarioActualizacion = value; }
        }

        String mstrFechaCierre = null;
        public String FechaCierre
        {
            get { return mstrFechaCierre; }
            set { mstrFechaCierre = value; }
        }

        String mstrUsuarioCierre = null;
        public String UsuarioCierre
        {
            get { return mstrUsuarioCierre; }
            set { mstrUsuarioCierre = value; }
        }
        #endregion
    }
}
