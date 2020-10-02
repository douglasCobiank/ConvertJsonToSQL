using System;

namespace ConverteToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Converter convert =new Converter();
            convert.ConverterParaSql(convert.abrirArquivo());

        }
    }
}
