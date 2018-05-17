using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM2017.Propiedades;

namespace CM2017.IU
{
    public class Concentrador
    {
        private Usuarios _Usuarios;
        private Sistema _Sistema;
        
        public Usuarios Usuarios
        {
            get { return _Usuarios; }
            set { _Usuarios = value; }
        }

        public Sistema Sistema
        {
            get { return _Sistema; }
            set { _Sistema = value;  }
        }

        public void Inicializar()
        {
            _Usuarios = new Usuarios();
            _Sistema = new Sistema();
        }
    }
}
