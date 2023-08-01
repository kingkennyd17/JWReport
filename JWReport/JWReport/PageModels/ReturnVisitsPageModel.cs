using JWReport.Database;
using JWReport.Models;
using JWReport.Models.Enum;
using JWReport.Models.HelperModel;
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
                var returnVisit = await _returnVisitRepository.GetReturnVisitAsync();
                List<RVPhoneMessageModel> returnVisitPHList = new List<RVPhoneMessageModel>();
                foreach (var item in returnVisit)
                {
                    RVPhoneMessageModel returnVisitPH = new RVPhoneMessageModel();
                    returnVisitPH.Address = item.Address;
                    returnVisitPH.NextMeeting = item.NextMeeting;
                    returnVisitPH.NextQuestion = item.NextQuestion;
                    returnVisitPH.Name = item.Name;
                    returnVisitPH.Id = item.Id;
                    returnVisitPH.Phone = item.Phone;
                    returnVisitPH.ReturnType = item.ReturnType;
                    returnVisitPH.Upgraded = item.Upgraded;
                    returnVisitPH.PhoneMessageViewModel = new PhoneMessageIconViewModel(item.Phone);

                    returnVisitPHList.Add(returnVisitPH);
                }
                ReturnVisitsMH = new ObservableCollection<RVPhoneMessageModel>(returnVisitPHList);
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

        private ObservableCollection<RVPhoneMessageModel> _returnVisitsMH;
        public ObservableCollection<RVPhoneMessageModel> ReturnVisitsMH
        {
            get => _returnVisitsMH;
            set => SetProperty(ref _returnVisitsMH, value);
        }
    }
}
