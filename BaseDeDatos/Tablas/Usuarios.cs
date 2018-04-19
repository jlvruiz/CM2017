using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using prop = CM2017.Propiedades;

namespace BaseDeDatos.Tablas
{
    public class Usuarios : BaseDeDatos
    {
        private int _idusuario;
        private string _nombre;
        private string _correo;
        private string _clave;
        private string _contra;
        private bool _visible;

        public int Idusuario { get => _idusuario; set => _idusuario = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public string Contra { get => _contra; set => _contra = value; }
        public bool Visible { get => _visible; set => _visible = value; }

        public DataTable UsuariosSelect()
        {
            string consulta = "SELECT IdResCM, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Visible, Clave, Contra FROM ResponsableCM ORDER BY Nombre";
            CreateTextCommand(consulta);
            return Select();
        }
        public List<prop.Usuarios> UsuariosSeleccion()
        {
            string consulta = "SELECT IdResCM, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Visible, Clave, Contra FROM ResponsableCM ORDER BY Nombre";
            CreateTextCommand(consulta);
            List<prop.Usuarios> usuarios = new List<prop.Usuarios>();
            for (int i = 0; i<Select().Rows.Count; i++)
            {
                prop.Usuarios usuario = new prop.Usuarios();
                {
                    usuario.IdResCM = int.Parse(Select().Rows[i]["IdResCM"].ToString());
                    usuario.Nombre = Select().Rows[i]["Nombre"].ToString();
                    usuario.Correo = Select().Rows[i]["Correo"].ToString();
                    usuario.Visible = int.Parse(Select().Rows[i]["Visible"].ToString() == "Activo" ? "1" : "0");
                    usuario.Clave = Select().Rows[i]["Clave"].ToString();
                    usuario.Contra = Select().Rows[i]["Contra"].ToString();
                }
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public DataTable UsuariosSelectById(prop.Usuarios item)
        {
            CreateTextCommand("SELECT IdResCM, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Visible, Clave, Contra FROM ResponsableCM WHERE IdResCM=?");
            AddParameter("?", item.IdResCM, OleDbType.Numeric);
            return Select();
        }

        public DataTable UsuarioSeleccionarPorId()
        {
            CreateTextCommand("SELECT IdResCM, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Visible, Clave, Contra FROM ResponsableCM WHERE IdResCM=?");
            AddParameter("?", _idusuario, OleDbType.Numeric);
            return Select();
        }

        public DataTable UsuariosBuscar(prop.Usuarios item)
        {
            CreateTextCommand("SELECT IdResCM, Nombre, Correo, SWITCH (Activo = 1, 'Activo', Activo = 0, 'Inactivo') AS Visible, Clave, Contra FROM ResponsableCM WHERE Nombre LIKE ? ");
            AddParameter("?", "%" + item.Nombre + "%", OleDbType.VarChar);
            return Select();
        }

        public string usuarioAgregar()
        {
            CreateTextCommand("INSERT INTO ResponsableCM (Nombre, Correo, Clave, Contra, Activo) VALUES (?,?,?,?,?)");
            AddParameter("?", _nombre, OleDbType.VarChar);
            AddParameter("?", _correo, OleDbType.VarChar);
            AddParameter("?", _clave, OleDbType.VarChar);
            AddParameter("?", _contra, OleDbType.VarChar);
            AddParameter("?", _visible, OleDbType.Numeric);
            return Insert();
        }

        public string UsuarioInsert(prop.Usuarios item)
        {
            CreateTextCommand("INSERT INTO ResponsableCM (Nombre, Correo, Clave, Contra, Activo) VALUES (?,?,?,?,?)");
            AddParameter("?", item.Nombre, OleDbType.VarChar);
            AddParameter("?", item.Correo, OleDbType.VarChar);
            AddParameter("?", item.Clave, OleDbType.VarChar);
            AddParameter("?", item.Contra, OleDbType.VarChar);
            AddParameter("?", item.Visible, OleDbType.Numeric);
            return Insert();
        }

        public int UsuarioDesactivar(prop.Usuarios item)
        {
            CreateTextCommand("UPDATE ResponsableCM SET Activo=? WHERE IdResCM=? ");
            AddParameter("?", item.Visible, OleDbType.Numeric);
            AddParameter("?", item.IdResCM, OleDbType.Numeric);
            return Update();
        }

        public int UsuarioUpdate(prop.Usuarios item)
        {
            CreateTextCommand("UPDATE ResponsableCM SET Nombre=?, Correo=?, clave=?, contra=?, Activo=? WHERE IdResCM=? ");
            AddParameter("?", item.Nombre, OleDbType.VarChar);
            AddParameter("?", item.Correo, OleDbType.VarChar);
            AddParameter("?", item.Clave, OleDbType.VarChar);
            AddParameter("?", item.Contra, OleDbType.VarChar);
            AddParameter("?", item.Visible, OleDbType.Numeric);
            AddParameter("?", item.IdResCM, OleDbType.Numeric);
            return Update();
        }

    }
}
