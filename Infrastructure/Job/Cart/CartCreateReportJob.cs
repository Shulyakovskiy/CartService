using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Job.Cart.Services;
using Infrastructure.Scheduler;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Persistence.Repository.Cart.Services;

namespace Infrastructure.Job.Cart
{
    /// <summary>
    /// Отчет по корзинам
    /// </summary>
    [UsedImplicitly]
    public class CartCreateReportJob : CronJobService
    {
        private readonly IJobCartService _jobCartService;
        private readonly ISaveDataToSource _saveDataToSource;
        private readonly ILogger<CartCreateReportJob> _logger;


        public CartCreateReportJob(IScheduleConfig<CartCreateReportJob> config,
            IJobCartService jobCartService, ISaveDataToSource saveDataToSource, ILogger<CartCreateReportJob> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _jobCartService = jobCartService;
            _saveDataToSource = saveDataToSource;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            //Generate Report Data
            _jobCartService.CreateReportData();
            //Save File Data
            SaveFileReport();
            _logger.LogInformation("CartCreateReportJob 3 starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CartCreateReportJob 3 is working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CartCreateReportJob 3 is stopping.");
            return base.StopAsync(cancellationToken);
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
            var path = @"D:\Report";
            var fileName =
                $"ReportCar-{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}.txt";
            _saveDataToSource.SafeDataToTxtFile(path, fileName, listLines);
        }

    }
}