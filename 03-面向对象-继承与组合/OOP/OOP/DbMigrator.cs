namespace OOP
{
    class DbMigrator
    {
        // 复合关系
        private readonly Logger _logger;

        public DbMigrator(Logger logger)
        {
            _logger = logger;
        }

        public void StartMigrator()
        {
            _logger.Log("数据迁移开始");
            // TODO: 处理数据迁移
        }
    }
}
