namespace ViFactory.BgServices
{
    public class ProjectDeleteBackgroundService : BackgroundService, IHostedService, IDisposable
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }

        public ProjectDeleteBackgroundService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            { 
                var projectsDirectory = Path.Combine(webHostEnvironment.WebRootPath, "projects");
                var cutoffTime = DateTime.Now.AddMinutes(-1);

                foreach (var directory in Directory.GetDirectories(projectsDirectory))
                {
                    var creationTime = Directory.GetCreationTime(directory);

                    if (creationTime < cutoffTime)
                    {
                        Directory.Delete(directory, true);
                    }
                }

                foreach (var file in Directory.GetFiles(projectsDirectory))
                {
                    var creationTime = Directory.GetCreationTime(file);

                    if (creationTime < cutoffTime)
                    {
                       File.Delete(file);
                    }
                }
                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
            }
        }
    }
}