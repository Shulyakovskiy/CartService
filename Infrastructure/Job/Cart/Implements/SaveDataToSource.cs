using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Infrastructure.Job.Cart.Services;

namespace Infrastructure.Job.Cart.Implements
{
    public class SaveDataToSource : ISaveDataToSource
    {
        /// <summary>
        /// Создание и сохранение файла с даннымим
        /// </summary>
        public Task SafeDataToTxtFile(string path, string name, List<string> data)
        {
            try
            {
                using StreamWriter sw = File.CreateText(path);
                foreach (var line in data)
                {
                    sw.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error - {e.Message}");
            }

            return Task.CompletedTask;
        }
    }
}