using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    /*    public void Like(string id, bool like)
        {
            bool? newLike = _newsService.Feedback(id, like);

            var updatedItem = NewsList.Single(x => x.ID == id);
            updatedItem.Like = newLike;
        }*/
    }
}
