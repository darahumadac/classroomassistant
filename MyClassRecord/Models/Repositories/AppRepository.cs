namespace MyClassRecord.Models.Repositories
{
    public class AppRepository
    {
        private IAppDataSource _dataSource;
        private Repository<User> _userRepository;
        private Repository<Student> _studentRepository;

        public AppRepository(IAppDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public Repository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new Repository<User>(_dataSource);
                }
                return _userRepository;
            }
        }

        public Repository<Student> StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new Repository<Student>(_dataSource);
                }
                return _studentRepository;
            }
        }

        public void Save()
        {
            _dataSource.Save();
        }

    }
}
