using System.Windows.Controls;
using System.Windows;

namespace Bakalarska_prace.Components
{
    public class ObservableGrid : Grid
    {
        // Event, který se spustí, když se změní vizuální děti Gridu
        public event EventHandler? ChildrenChanged;

        // Tuto metodu automaticky volá WPF, když se něco přidá nebo odebere z Grid.Children
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);

            // Vyvolání eventu - upozorní posluchače, že došlo ke změně
            ChildrenChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
