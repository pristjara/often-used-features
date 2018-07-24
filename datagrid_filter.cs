private void txtFiltrs_TextChanged(object sender, TextChangedEventArgs e)
{
    try
    {
        CollectionView collection = (CollectionView)CollectionViewSource.GetDefaultView(datagrid.ItemsSource);
        collection.Filter = new Predicate<object>(filter);
        CollectionViewSource.GetDefaultView(datagrid.Items).Refresh();
    }
    catch (Exception)
    {
    }
}

private bool filter(object item)
{
    return string.IsNullOrEmpty(txtFiltrs.Text)
        || (item as %class_name%).ID.ToString().IndexOf(txtFiltrs.Text.Trim(), StringComparison.OrdinalIgnoreCase) >= 0
        ;
}
