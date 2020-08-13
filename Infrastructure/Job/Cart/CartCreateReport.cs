using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Infrastructure.Job.Cart.Services;
using Persistence.Repository.Cart.Services;
using Quartz;

namespace Infrastructure.Job.Cart
{
    /// <summary>
    /// Отчет по корзинам
    /// </summary>
    public class CartCreateReport : IJob
    {
        private readonly IJobCartService _jobCartService;
        private readonly ISaveDataToSource _saveDataToSource;

        public CartCreateReport(IJobCartService jobCartService, ISaveDataToSource saveDataToSource)
        {
            _jobCartService = jobCartService;
            _saveDataToSource = saveDataToSource;
        }

        public Task Execute(IJobExecutionContext context)
        {
            //Generate Report Data
            _jobCartService.CreateReportData();
            //Save File Data
            SaveFileReport();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Сохранение созданного отчета
        /// </summary>
        private void SaveFileReport()
        {
            var listLines = new List<string>();
            var cartInfo = _jobCartService.CartInfoGet();
            var cartAvgList = _jobCartService.CartAvgCheckGet();

            listLines.Add("============= Report Cart =============");
            listLines.Add($"Всего корзин: {cartInfo.TotalCart}\n");
            listLines.Add($"Сколько из них содержат продукты за баллы: { cartInfo.CartProductOfBonus}\n");
            listLines.Add($"Истекает срок через 10 дней: { cartInfo.CartExpire10Day}\n");
            listLines.Add($"Истекает срок через 10 дней: { cartInfo.CartExpire20Day}\n");
            listLines.Add($"Истекает срок через 10 дней: { cartInfo.CartExpire30Day}\n");
            listLines.Add("=======================================");
            listLines.Add("============== AVG Check Cart ===============");
            foreach (var card in cartAvgList)
            {
                listLines.Add($"Корзина: { card.CartId} - Среднее: {card.CartAvgCheck}\n");
            }
            //TODO: get from config or storage
            var path = Assembly.GetEntryAssembly()?.GetName().CodeBase;
            _saveDataToSource.SafeDataToTxtFile(path, $"ReportCar-{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}.txt", listLines);
        }
    }
}