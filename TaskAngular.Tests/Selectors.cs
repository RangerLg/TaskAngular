namespace TaskAngular.Tests
{
    public class Selectors
    {
        protected const string LoginButtonXPath = "/html/body/app-root/mat-card[2]/button[1]";
        protected const string RegisterButtonXPath = "/html/body/app-root/mat-card[2]/button[2]";

        protected readonly string LoginFormXPath =
            "/html/body/app-root/" + "mat-card[2]/mat-form-field[1]" + "/div/div[1]/div/input";

        protected const string PasswordFormXPath =
            "/html/body/app-root/mat-card[2]/mat-form-field[2]/div/div[1]/div/input";

        protected const string AddCollectionButtonXPath =
            "/html/body/app-root/app-home/mat-card/div/a/button";

        protected const string CollectionNameFormXPath = "/html/body/app-root/app-add-collection/form/div[1]/input";
        protected const string CollectionTopicFormXPath = "/html/body/app-root/app-add-collection/form/div[2]/input";
        protected const string CollectionDescFormXPath = "/html/body/app-root/app-add-collection/form/div[3]/input";
        protected const string AddCollectionFormButtonXPath = "/html/body/app-root/app-add-collection/form/button";

        protected const string MyCollectionButtonXpath = "/html/body/app-root/mat-card[1]/a[2]/button";

        protected const string CollectionMoreXpath =
            "/html/body/app-root/app-my-collection/mat-card/mat-table/mat-row[1]/mat-cell[5]/a/button";

        protected const string AddItemButtonXPath = "/html/body/app-root/app-collection-page/mat-card/div/a/button";
        protected const string AddItemNameFormXPath = "/html/body/app-root/app-add-item/form/div/input";
        protected const string AddItemFormButtonXPath = "/html/body/app-root/app-add-item/form/button";
    }
}