using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConverteToJson
{
    public class Converter
    {
        //int val_item = 0;
        string sql = "";
        public List <DadosJson> abrirArquivo(string arquivo){
            //string arquivo = Environment.CurrentDirectory + @"\arquivo_nomes.json";
            StreamReader ler = new StreamReader(arquivo);
            var retorno = JsonConvert.DeserializeObject<List<DadosJson>>(ler.ReadToEnd());
            
            ler.Close();
            return retorno;
        }

        public void LeArquivo(List <DadosJson> campo, List <DadosJson> formalario){
            StreamWriter arquivo = new StreamWriter(Environment.CurrentDirectory + @"\arquivo_ids.SQL");
            
            foreach (var id in formalario)
            {
                foreach(var valor in campo)
                {
                    if(id.Nome == valor.Formulario)
                    {
                        sql += "INSERT INTO CAMPO_FORMULARIO (CAFO_FK_FORM_CODIGO, CAFO_FK_CAM_CODIGO)" + 
                               "VALUES((SELECT F.FORM_CODIGO " +  
                               "FROM FORMULARIO F " +  
                               "WHERE F.NOME = '"+ id.Nome +"')" +
                               ", (SELECT C.CAM_CODIGO " + 
                               "FROM CAMPO C " + 
                               "WHERE C.CAM_LABEL = '" + valor.Pergunta + "'));\n";
                    }
                }   
            }

            arquivo.WriteLine(sql);
            Console.WriteLine("Arquivo gerado com sucesso");
            Console.WriteLine(Environment.CurrentDirectory + @"\arquivo_ids.SQL");
            arquivo.Close();
        }
        public void ConverterParaSql(List <DadosJson> lista){
            StreamWriter arquivo = new StreamWriter(Environment.CurrentDirectory + @"\arquivo_nomes.SQL");
            
            foreach (var item in lista)
            {

                /*switch(item.Tipo){
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
                }*/
                //sql += "INSERT INTO FORMULARIO (FORM_NOME, FORM_STATUS) VALUES ('" + item.Nome + "'," + 1 + ");\n";
                //sql += "INSERT INTO CAMPO (CAM_LABEL, CAM_TIPO, ) VALUES ('" + item.Pergunta  + "','"+ item.Tipo + "','" + item.Formulario + "');\n";
                //sql += "UPDATE [ADD].[dbo].[MotivosTransacao] SET DESCRICAO = '" + item.Descricao + "' WHERE ID = " + item.Id + ";\n";
            }

            arquivo.WriteLine(sql);
            Console.WriteLine("Arquivo gerado com sucesso");
            Console.WriteLine(Environment.CurrentDirectory + @"\arquivo_nomes.SQL");
            arquivo.Close();
        }
        
    }
}