public class HeroPresenter
{
    private readonly IHeroView _view;
    private readonly HeroModel _model;

    public HeroPresenter(IHeroView view, HeroModel model)
    {
        _view = view;
        _model = model;

        InitializeView();
    }

    public void InitializeView()
    {
        _view.DisplayHeroName(_model.Name);
        _view.DisplayHeroLevel(_model.Level);
        _view.DisplayHeroStatus(_model.IsSelected);
        _model.OnLevelChanged += ChangeHeroLevel;
    }

    public void ChangeHeroLevel()
    {
        _view.DisplayHeroLevel(_model.Level);
    }
}
