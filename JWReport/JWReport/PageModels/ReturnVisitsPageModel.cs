using JWReport.Database;
using JWReport.Models;
using JWReport.Models.Enum;
using JWReport.PageModels.Base;
using JWReport.Services.Interface;
using JWReport.Services.Repository;
using JWReport.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace JWReport.PageModels
{
    public class ReturnVisitsPageModel : PageModelBase
    {
        private IReturnVisitRepository _returnVisitRepository;
        public ReturnVisitsPageModel(IReturnVisitRepository returnVisitRepository) 
        {
            _returnVisitRepository = returnVisitRepository;

            OnInit();
        }

        //private string itemId;
        //public string ItemId
        //{
        //    get
        //    {
        //        return itemId;
        //    }
        //    set
        //    {
        //        itemId = value;
        //        //OnInit(value);
        //    }
        //}

        public async void OnInit()
        {
            try
            {
                BaseRepository<ReturnVisit> database = await ReturnVisitRepository.Instance;
                ReturnVisits = new ObservableCollection<ReturnVisit>( await _returnVisitRepository.GetReturnVisitAsync());
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private ObservableCollection<ReturnVisit> _returnVisits;
        public ObservableCollection<ReturnVisit> ReturnVisits
        {
            get => _returnVisits;
            set => SetProperty(ref _returnVisits, value);
        }
    }
}
