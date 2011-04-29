namespace NerdDinner.ViewProviders {

    public static class ViewProviders {
        private static readonly ViewProviderCollection pathProviders = new ViewProviderCollection();

        static ViewProviders() {
            // Register these view path providers
            pathProviders.Add(new MobileViewProvider());
            pathProviders.Add(new IPhoneViewProvider());
            pathProviders.Add(new AndroidViewProvider());
        }

        public static ViewProviderCollection Providers {
            get { return pathProviders; }
        }
    }
}
