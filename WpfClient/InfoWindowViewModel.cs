using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfClient.Model;

namespace WpfClient
{
    public class InfoWindowViewModel : INotifyPropertyChanged
    {
        private InfoService _infoService { get; set; }
        private ObservableCollection<Model.Info> _infoList;
        public ObservableCollection<Model.Info> InfoList
        {
            get { return _infoList; }
            set
            {
                _infoList = value;
                OnPropertyChanged(nameof(InfoList));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public InfoWindowViewModel()
        {
            _infoService = new InfoService();
            Update();
        }

        public void Update()
        {
            var infos = _infoService.GetAllInfos();
            InfoList = new ObservableCollection<Model.Info>(infos);
        }

        public void Like(Info inf, bool like)
        {
            bool newLike = _infoService.Feedback(inf, like);

            var updatedItem = InfoList.Single(x => x.id == inf.id);
            updatedItem.like = newLike;
        }
    }
}
