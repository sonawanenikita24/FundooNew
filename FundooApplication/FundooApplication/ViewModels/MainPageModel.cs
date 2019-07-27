//--------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPageModel.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using Xamarin.Forms;
    using static FundooApplication.Model.TypeOfNote;

    /// <summary>
    /// Page model input for bar graph and display bar graph model
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class MainPageModel : INotifyPropertyChanged
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
        /// Gets or sets the graph model.
        /// </summary>
        /// <value>
        /// The graph model.
        /// </value>
        private PlotModel graphModel { get; set; }

        /// <summary>
        /// Gets or sets the graph model.
        /// </summary>
        /// <value>
        /// The graph model.
        /// </value>
        public PlotModel GraphModel
        {
            get
            {
                return this.graphModel;
            }

            set
            {
                this.graphModel = value;
            }
        }

        /// <summary>
        /// Gets or sets the button load graph.
        /// </summary>
        /// <value>
        /// The button load graph.
        /// </value>
        public ICommand BtnLoadGraph { get; set; }

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
        /// Initializes a new instance of the <see cref="MainPageModel"/> class.
        /// </summary>
        public MainPageModel()
        {
            GraphModel = new PlotModel();
            BtnLoadGraph = new Command(LoadBarChart);
        }

        /// <summary>
        /// Loads the bar chart.
        /// </summary>
        public async void LoadBarChart()
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

            GraphModel = null;
            OnPropertyChanged("GraphModel");
            var model = new PlotModel { Title = "Kind of notes created by user." };

            var barSeries = new ColumnSeries
            {
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}"
            };

            barSeries.Items.Add(new ColumnItem
            {
                Value = Convert.ToDouble(PinnedList.Count),
                Color = OxyColor.Parse("#3498db")
            });

            barSeries.Items.Add(new ColumnItem
            {
                Value = Convert.ToDouble(ArchivedList.Count),
                Color = OxyColor.Parse("#2ecc71")
            });

            barSeries.Items.Add(new ColumnItem
            {
                Value = Convert.ToDouble(TrashedList.Count),
                Color = OxyColor.Parse("#9b59b6")
            });

            barSeries.Items.Add(new ColumnItem
            {
                Value = Convert.ToDouble(OthersList.Count),
                Color = OxyColor.Parse("#34495e")
            });

            model.Series.Add(barSeries);
            String[] strNames = new String[] { "Pinned", "Archived", "Trashed", "Others" };
            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Key = "Sample Data",
                ItemsSource = strNames
            });

            GraphModel = model;
            OnPropertyChanged("GraphModel");
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