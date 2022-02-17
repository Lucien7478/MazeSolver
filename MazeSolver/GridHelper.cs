using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MazeSolver
{
    public class GridHelper
    {
        #region RowCount Property

        /// <summary>
        /// Adds the specified number of Rows to RowDefinitions. 
        /// Default Height is Auto
        /// </summary>
        public static readonly DependencyProperty RowCountProperty =
            DependencyProperty.RegisterAttached(
                "RowCount", typeof(int), typeof(GridHelper),
                new PropertyMetadata(-1, RowCountChanged));

        // Get
        public static int GetRowCount(DependencyObject obj)
        {
            return (int)obj.GetValue(RowCountProperty);
        }

        // Set
        public static void SetRowCount(DependencyObject obj, int value)
        {
            obj.SetValue(RowCountProperty, value);
        }

        // Change Event - Adds the Rows
        public static void RowCountChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || (int)e.NewValue < 0)
                return;

            Grid grid = (Grid)obj;
            grid.RowDefinitions.Clear();

            for (int i = 0; i < (int)e.NewValue; i++) 
                grid.RowDefinitions.Add(new RowDefinition());

            foreach(var child in grid.Children.OfType<TextBlock>().ToList())
            {
                if(grid.Name != "Goal" && grid.Name != "Player")
                    grid.Children.Remove(child);
            }
            for (int x = 0; x < grid.RowDefinitions.Count; x++)
            {
                for (int y = 0; y < grid.ColumnDefinitions.Count; y++)
                {
                    var txtBlock = new TextBlock();
                    txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    txtBlock.VerticalAlignment = VerticalAlignment.Center;
                    txtBlock.SetValue(Grid.RowProperty, x);
                    txtBlock.SetValue(Grid.ColumnProperty, y);
                    txtBlock.Text = "" + x + " " + y;
                    grid.Children.Add(txtBlock);
                }
            }
        }

        #endregion

        #region ColumnCount Property

        /// <summary>
        /// Adds the specified number of Columns to ColumnDefinitions. 
        /// Default Width is Auto
        /// </summary>
        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.RegisterAttached(
                "ColumnCount", typeof(int), typeof(GridHelper),
                new PropertyMetadata(-1, ColumnCountChanged));

        // Get
        public static int GetColumnCount(DependencyObject obj)
        {
            return (int)obj.GetValue(ColumnCountProperty);
        }

        // Set
        public static void SetColumnCount(DependencyObject obj, int value)
        {
            obj.SetValue(ColumnCountProperty, value);
        }

        // Change Event - Add the Columns
        public static void ColumnCountChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || (int)e.NewValue < 0)
                return;

            Grid grid = (Grid)obj;
            grid.ColumnDefinitions.Clear();

            for (int i = 0; i < (int)e.NewValue; i++)
                grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        #endregion

        #region BlockObjects Property

        /// <summary>
        /// Adds the specified number of Columns to ColumnDefinitions. 
        /// Default Width is Auto
        /// </summary>
        public static readonly DependencyProperty BlockObjectsProperty =
            DependencyProperty.RegisterAttached(
                "BlockObjects", typeof(object), typeof(GridHelper),
                new PropertyMetadata(-1, BlockObjectsChanged));

        // Get
        public static List<BlockObject> GetBlockObjects(DependencyObject obj)
        {
            return (List<BlockObject>)obj.GetValue(ColumnCountProperty);
        }

        // Set
        public static void SetBlockObjects(DependencyObject obj, List<BlockObject> value)
        {
            obj.SetValue(ColumnCountProperty, value);
        }

        // Change Event - Add the Columns
        public static void BlockObjectsChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid))
                return;

            Grid grid = (Grid)obj;            
            List<BlockObject> blockObjects = (List<BlockObject>) obj.GetValue(BlockObjectsProperty);

            List<Image> images = grid.Children.OfType<Image>().ToList();
            for (int i = 0; i < images.Count; i++)
            {
                if (images[i].Name != "Player" && images[i].Name != "Goal") grid.Children.Remove(images[i]);
            }

            blockObjects.ForEach(bObject => {
                Image image = new();
                Binding sourceBinding = new("Source");
                sourceBinding.Source = bObject;

                Binding columnBinding = new("PosX");
                columnBinding.Source = bObject;
                Binding rowBinding = new("PosY");
                rowBinding.Source = bObject;

                image.SetBinding(Image.SourceProperty, sourceBinding);
                image.SetBinding(Grid.ColumnProperty, columnBinding);
                image.SetBinding(Grid.RowProperty, rowBinding);
                grid.Children.Add(image);
            });
        }

        #endregion
    }
}
