using System;

namespace ConverteToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Converter convert =new Converter();
            //convert.ConverterParaSql(convert.abrirArquivo(Environment.CurrentDirectory + @"\arquivo_nomes.json"));
            convert.LeArquivo(convert.abrirArquivo(Environment.CurrentDirectory + @"\campo_formulario.json"), convert.abrirArquivo(Environment.CurrentDirectory + @"\formulario.json"));

        }
    }
}
