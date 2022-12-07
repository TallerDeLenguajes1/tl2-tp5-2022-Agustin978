namespace Cadeteria.Models
{
    public class helper
    {
        private string path;
        private string ext;

        public helper(string path, string ext)
        {
            this.path = path;
            this.ext = ext;
        }

        public void compruebaCarpeta()
        {
            if(!File.Exists(this.path+this.ext))
            {
                var myFile = File.Create(this.path + this.ext);
                myFile.Close();
            }
        }

        public List<CadeteModel> cadetesAlmacenados()
        {
            compruebaCarpeta();
            List<CadeteModel> cadetes = new List<CadeteModel>();
            using (FileStream archivo = new FileStream(this.path+this.ext, FileMode.Open))
            {
                using(StreamReader strRead = new StreamReader(archivo))
                {
                    string linea = "";
                    while((linea = strRead.ReadLine()) != null)
                    {
                        var datos = linea.Split(",");
                        cadetes.Add(new CadeteModel(int.Parse(datos[0]), datos[1], datos[2], float.Parse(datos[3]), datos[4]));
                    }
                }
            }
            return cadetes;
        }

        public void agregaCadete(CadeteModel cadete)
        {
            string linea = $"{cadete.getID()},{cadete.getNombre()},{cadete.getTelefono()},{cadete.getJornal()},{cadete.getDireccion()}";
            using(FileStream archivo = new FileStream(this.path+this.ext, FileMode.Append))
            {
                using(StreamWriter strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine(linea);
                }
            }
        }

        public List<PedidoModel> pedidosAlmacenados()
        {
            compruebaCarpeta();
            List<PedidoModel> listaPedidos = new List<PedidoModel>();
            using(FileStream archivos = new FileStream(this.path + this.ext, FileMode.Open))
            {
                using(StreamReader strReader = new StreamReader(archivos))
                {
                    string linea = "";
                    while((linea = strReader.ReadLine()) != null)
                    {
                        var datos = linea.Split(",");
                        listaPedidos.Add(new PedidoModel(int.Parse(datos[0]), datos[1], datos[2], datos[3], datos[4], datos[5], datos[6]));
                    }
                }
            }
            return listaPedidos;
        }

        public void agregaPedido(PedidoModel pedido)
        {
            string linea = $"{pedido.getNroPedido()},{pedido.getObservacion()},{pedido.getDatosExtraDireccion()},{pedido.getCliente().getNombre()},{pedido.getCliente().getDireccion()},{pedido.getCliente().getTelefono()},{pedido.getEstado()}\n";
            using (FileStream archivo = new FileStream(this.path + this.ext, FileMode.Append)) 
            {
                using (StreamWriter strWriter = new StreamWriter(archivo))
                {
                    strWriter.Write(linea);
                }
            }
        }  
    }
}
