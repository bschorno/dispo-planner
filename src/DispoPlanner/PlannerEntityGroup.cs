using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DispoPlanner
{
    /// <summary>
    /// Represents a entity group which holds multiple entities
    /// </summary>
    public class PlannerEntityGroup : ItemsControl
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerEntityGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerEntityGroup), new FrameworkPropertyMetadata(typeof(PlannerEntityGroup)));
        }

        /// <summary>
        /// Create new instance of <see cref="PlannerEntityGroup"/>
        /// </summary>
        public PlannerEntityGroup()
            : base()
        {
            SetValue(EntitiesProperty, new ObservableCollection<IPlannerEntity>());
        }

        /// <summary>
        /// Identifies the Title dependency property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PlannerEntityGroup), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the title of this group
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the VisibleGroup dependency property
        /// </summary>
        public static readonly DependencyProperty VisibleGroupProperty = DependencyProperty.Register("VisibleGroup", typeof(bool), typeof(PlannerEntityGroup), new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets if this group should be visible as an entity group
        /// </summary>
        public bool VisibleGroup
        {
            get { return (bool)GetValue(VisibleGroupProperty); }
            set { SetValue(VisibleGroupProperty, value); }
        }

        /// <summary>
        /// Identifies the Entities dependency property
        /// </summary>
        public static readonly DependencyProperty EntitiesProperty = DependencyProperty.Register("Entities", typeof(ObservableCollection<IPlannerEntity>), typeof(PlannerEntityGroup), new PropertyMetadata(new ObservableCollection<IPlannerEntity>()));

        /// <summary>
        /// Gets or sets the entities which will be drawn
        /// </summary>
        public ObservableCollection<IPlannerEntity> Entities
        {
            get { return (ObservableCollection<IPlannerEntity>)GetValue(EntitiesProperty); }
            set { SetValue(EntitiesProperty, value); }
        }
    }
}
