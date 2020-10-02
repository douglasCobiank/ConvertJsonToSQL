using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConverteToJson
{
    public class Converter
    {
        public List <DadosJson> abrirArquivo(){
            string arquivo = Environment.CurrentDirectory + @"\arquivos.json";
            StreamReader ler = new StreamReader(arquivo);
            var retorno = JsonConvert.DeserializeObject<List<DadosJson>>(ler.ReadToEnd());
            
            ler.Close();
            return retorno;
        }

        public void ConverterParaSql(List <DadosJson> lista){
            string sql = "";
            int val_item = 0;
            StreamWriter arquivo = new StreamWriter(Environment.CurrentDirectory + @"\INSERT.SQL");
            
            foreach (var item in lista)
            {
                switch(item.TIPO){
                    case "Campo Fotografia":
                        val_item = 3;
                        break;
                    case "Campo Texto":
                        val_item = 9;
                        break;
                    case "Campo Assinatura":
                        val_item = 1;
                        break;
                    case "Campo Instrução":
                        val_item = 9;
                        break;
                    case "Campo Numérico":
                        val_item = 6;
                        break;
                    case "Campo Sim/Não":
                        val_item = 8;
                        break;
                    case "Campo Data":
                        val_item = 9;
                        break;
                    case "Campo Hora":
                        val_item = 9;
                        break;
                }

                sql += "INSERT INTO CAMPO (CAM_LABEL, CAM_TIPO) VALUES ('" + item.Pergunta  + "','"+ val_item.ToString() + "');\n";
            }

            arquivo.WriteLine(sql);
            Console.WriteLine("Arquivo gerado com sucesso");
            Console.WriteLine(Environment.CurrentDirectory + @"\INSERT.SQL");
            arquivo.Close();
        }
        
    }
}