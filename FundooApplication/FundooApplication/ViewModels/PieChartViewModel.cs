using FundooApplication.Model;
using FundooApplication.Repository;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static FundooApplication.Model.TypeOfNote;

namespace FundooApplication.ViewModels
{
    /// <summary>
    /// model class for pie chart
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class PieChartViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The others list for storing note type
        /// </summary>
        IList<Note> OthersList = new List<Note>();

        /// <summary>
        /// The pinned list for storing note of pin type
        /// </summary>
        IList<Note> PinnedList = new List<Note>();

        /// <summary>
        /// The archived list is used for storing archived type note
        /// </summary>
        IList<Note> ArchivedList = new List<Note>();

        /// <summary>
        /// The trashed list is used for storing note of trash type
        /// </summary>
        IList<Note> TrashedList = new List<Note>();

        /// <summary>
        /// Gets or sets the pie model.
        /// </summary>
        /// <value>
        /// The pie model.
        /// </value>
        private PlotModel pieModel { get; set; }

        /// <summary>
        /// Gets or sets the pie model.
        /// </summary>
        /// <value>
        /// The pie model.
        /// </value>
        public PlotModel PieModel
        {
            get
            {
                return pieModel;
            }

            set
            {
                pieModel = value;
            }
        }

        /// <summary>
        /// Gets or sets the BTN pie graph.
        /// </summary>
        /// <value>
        /// The BTN pie graph.
        /// </value>
        public ICommand ButtonPieGraph { get; set; }

        /// <summary>
        /// Gets or sets the helper.
        /// </summary>
        /// <value>
        /// The helper.
        /// </value>
        public NotesRepository Helper
        {
            get
            {
                return this.helper;
            }

            set
            {
                this.helper = value;
            }
        }

        /// <summary>
        /// firebase helper to access database
        /// </summary>
        private NotesRepository helper = new NotesRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="PieChartViewModel"/> class.
        /// </summary>
        public PieChartViewModel()
        {
            PieModel = new PlotModel();
            ButtonPieGraph = new Command(LoadPieChart);
        }

        /// <summary>
        /// Loads the pie chart.
        /// </summary>
        public async void LoadPieChart()
        {
            ////get all notes from the database
            var allNotes = await Helper.GetAllUserNotes();

            ////Others Notes
            foreach (var item in allNotes)
            {
                if (item.NoteType == NoteType.isNote)
                {
                    OthersList.Add(item);
                }
            }

            ////Pin Notes
            foreach (var item in allNotes)
            {
                if (item.NoteType == NoteType.ispin)
                {
                    PinnedList.Add(item);
                }
            }

            ////archive Notes
            foreach (var item in allNotes)
            {
                if (item.NoteType == NoteType.isArchive)
                {
                    ArchivedList.Add(item);
                }
            }

            ////trash Notes
            foreach (var item in allNotes)
            {
                if (item.NoteType == NoteType.isTrash)
                {
                    TrashedList.Add(item);
                }
            }

            PieModel = null;
            OnPropertyChanged("PieModel");
            var model = new PlotModel { Title = "Kind of notes created by user." };
            var ps = new PieSeries
            {
                StrokeThickness = 0.25,
                AngleSpan = 360,
                StartAngle = 0,
                InsideLabelFormat = "",
                OutsideLabelFormat = "{1}: {0}",
                TickHorizontalLength = 20,
                TickRadialLength = 2
            };

            ps.Slices.Add(new PieSlice("PinnedNote", Convert.ToDouble(PinnedList.Count)) { IsExploded = false, Fill = OxyColor.Parse("#3498db") });
            ps.Slices.Add(new PieSlice("OtherList", Convert.ToDouble(OthersList.Count)) { IsExploded = false, Fill = OxyColor.Parse("#2ecc71") });
            ps.Slices.Add(new PieSlice("ArchivedNote", Convert.ToDouble(ArchivedList.Count)) { IsExploded = false, Fill = OxyColor.Parse("#9b59b6") });
            ps.Slices.Add(new PieSlice("TrashNote", Convert.ToDouble(TrashedList.Count)) { IsExploded = false, Fill = OxyColor.Parse("#34495e") });

            model.Series.Add(ps);
            PieModel = model;

            OnPropertyChanged("PieModel");
        }

        #region INotifyChangedProperties        
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyChangedProperties
    }
}
