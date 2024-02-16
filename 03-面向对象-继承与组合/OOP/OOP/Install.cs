namespace OOP
{
    class Install
    {
        private readonly Logger _logger;

        public Install(Logger logger)
        {
            _logger = logger;
        }

        public void StartInstall()
        {
            _logger.Log("安装开始");
            // TODO: 处理安装
        }
    }
}
