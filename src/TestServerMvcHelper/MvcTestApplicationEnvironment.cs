using Microsoft.Dnx.Runtime;
using System.Runtime.Versioning;

namespace TestServerMvcHelper
{

    public class MvcTestApplicationEnvironment : IApplicationEnvironment
    {
        private readonly IApplicationEnvironment _originalAppEnvironment;
        private readonly string _applicationBasePath;
        private readonly string _applicationName;

        public MvcTestApplicationEnvironment(IApplicationEnvironment originalAppEnvironment, string appName, string appBasePath)
        {
            _originalAppEnvironment = originalAppEnvironment;
            _applicationBasePath = appBasePath;
            _applicationName = appName;
        }

        public string ApplicationName
        {
            get { return _applicationName; }
        }

        public string ApplicationVersion
        {
            get { return _originalAppEnvironment.ApplicationVersion; }
        }

        public string ApplicationBasePath
        {
            get { return _applicationBasePath; }
        }

        public string Configuration
        {
            get
            {
                return _originalAppEnvironment.Configuration;
            }
        }

        public FrameworkName RuntimeFramework
        {
            get { return _originalAppEnvironment.RuntimeFramework; }
        }

        public object GetData(string name)
        {
            return _originalAppEnvironment.GetData(name);
        }

        public void SetData(string name, object value)
        {
            _originalAppEnvironment.SetData(name, value);
        }

    }
}
