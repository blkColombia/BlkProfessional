using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCL
{
    public class GFCierreFinancieroDetalle
    {
        #region Propiedades

        public GFCierreFinancieroDetalle() { }

        public GFCierreFinancieroDetalle(Int64? _mintIdCierreDetalle,
                        Int64? _mintIdCierre,
                        String _mstrTerminal,
                        String _mstrAlmacen,
                        String _mstrCodCliente,
                        Int64? _mintIdConcepto,
                        String _mstrValorConcepto,
                        String _mstrEstado,
                        String _mstrFechaCreacion,
                        String _mstrUsuarioCreacion,
                        String _mstrFechaActualizacion,
                        String _mstrUsuarioActualizacion,
                        String _mstrFechaFinalizacion,
                        String _mstrUsuarioFinalizacion
                        )
        {
            mintIdCierreDetalle = _mintIdCierreDetalle;
            mintIdCierre = _mintIdCierre;
            mstrTerminal = _mstrTerminal;
            mstrAlmacen = _mstrAlmacen;
            mstrCodCliente = _mstrCodCliente;
            mintIdConcepto = _mintIdConcepto;
            mstrValorConcepto = _mstrValorConcepto;
            mstrEstado = _mstrEstado;
            mstrFechaCreacion = _mstrFechaCreacion;
            mstrUsuarioCreacion = _mstrUsuarioCreacion;
            mstrFechaActualizacion = _mstrFechaActualizacion;
            mstrUsuarioActualizacion = _mstrUsuarioActualizacion;
            mstrFechaFinalizacion = _mstrFechaFinalizacion;
            mstrUsuarioFinalizacion = _mstrUsuarioFinalizacion;
        }

        public GFCierreFinancieroDetalle(IDataRecord obj)
        {
            mintIdCierreDetalle = Convert.ToInt64(obj["IdCierreDetalle"]);
            mintIdCierre = Convert.ToInt64(obj["IdCierre"]);
            mstrTerminal = Convert.ToString(obj["Terminal"]);
            mstrAlmacen = Convert.ToString(obj["Almacen"]);
            mstrCodCliente = Convert.ToString(obj["CodCliente"]);
            mintIdConcepto = Convert.ToInt64(obj["IdConcepto"]);
            mstrValorConcepto = Convert.ToString(obj["ValorConcepto"]);
            mstrEstado = Convert.ToString(obj["Estado"]);
            mstrFechaCreacion = Convert.ToString(obj["FechaCreacion"]);
            mstrUsuarioCreacion = Convert.ToString(obj["UsuarioCreacion"]);
            mstrFechaActualizacion = Convert.ToString(obj["FechaActualizacion"]);
            mstrUsuarioActualizacion = Convert.ToString(obj["UsuarioActualizacion"]);
            mstrFechaFinalizacion = Convert.ToString(obj["FechaFinalizacion"]);
            mstrUsuarioFinalizacion = Convert.ToString(obj["UsuarioFinalizacion"]);
        }

        public GFCierreFinancieroDetalle(DataRow obj)
        {
            mintIdCierreDetalle = Convert.ToInt64(obj["IdCierreDetalle"]);
            mintIdCierre = Convert.ToInt64(obj["IdCierre"]);
            mstrTerminal = Convert.ToString(obj["Terminal"]);
            mstrAlmacen = Convert.ToString(obj["Almacen"]);
            mstrCodCliente = Convert.ToString(obj["CodCliente"]);
            mintIdConcepto = Convert.ToInt64(obj["IdConcepto"]);
            mstrValorConcepto = Convert.ToString(obj["ValorConcepto"]);
            mstrEstado = Convert.ToString(obj["Estado"]);
            mstrFechaCreacion = Convert.ToString(obj["FechaCreacion"]);
            mstrUsuarioCreacion = Convert.ToString(obj["UsuarioCreacion"]);
            mstrFechaActualizacion = Convert.ToString(obj["FechaActualizacion"]);
            mstrUsuarioActualizacion = Convert.ToString(obj["UsuarioActualizacion"]);
            mstrFechaFinalizacion = Convert.ToString(obj["FechaFinalizacion"]);
            mstrUsuarioFinalizacion = Convert.ToString(obj["UsuarioFinalizacion"]);
        }

        #endregion

        #region Constructores

        Int64? mintIdCierreDetalle = null;
        public Int64? IdCierreDetalle
        {
            get { return mintIdCierreDetalle; }
            set { mintIdCierreDetalle = value; }
        }

        Int64? mintIdCierre = null;
        public Int64? IdCierre
        {
            get { return mintIdCierre; }
            set { mintIdCierre = value; }
        }

        String mstrTerminal = null;
        public String Terminal
        {
            get { return mstrTerminal; }
            set { mstrTerminal = value; }
        }

        String mstrAlmacen = null;
        public String Almacen
        {
            get { return mstrAlmacen; }
            set { mstrAlmacen = value; }
        }

        String mstrCodCliente = null;
        public String CodCliente
        {
            get { return mstrCodCliente; }
            set { mstrCodCliente = value; }
        }

        Int64? mintIdConcepto = null;
        public Int64? IdConcepto
        {
            get { return mintIdConcepto; }
            set { mintIdConcepto = value; }
        }

        String mstrValorConcepto = null;
        public String ValorConcepto
        {
            get { return mstrValorConcepto; }
            set { mstrValorConcepto = value; }
        }

        String mstrEstado = null;
        public String Estado
        {
            get { return mstrEstado; }
            set { mstrEstado = value; }
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


        String mstrFechaFinalizacion = null;
        public String FechaFinalizacion
        {
            get { return mstrFechaFinalizacion; }
            set { mstrFechaFinalizacion = value; }
        }

        String mstrUsuarioFinalizacion = null;
        public String UsuarioFinalizacion
        {
            get { return mstrUsuarioFinalizacion; }
            set { mstrUsuarioFinalizacion = value; }
        }



        #endregion
    }
}
