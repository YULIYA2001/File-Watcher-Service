# term3_ISP_Lab3

Cutf(en).txt - файлик для проверки работы сервиса (шифрования, архивирования)

config.xml и appsettings.json лежат в FileWatcherService\FileWatcherService\bin\Debug
путь к sourse и target: C:\\LAB3\\Sourse...(создастся сам, но можно поменять диск)

FileWatcherLibrary - хранит всю реализацию

FileWatcherService - хранит только классы для службы

Для запуска службы: в командной строке указать путь к .exe файлу службы (...FileWatcherService\FileWatcherService\bin\Debug)
Далее прописать InstallUtil.exe FileWatcherService.exe - служба запущена (InstallUtil.exe я добавила в ту же папку, что и FileWatcherService.exe)
Для выгрузки службы ввести: InstallUtil.exe /u FileWatcherService.exe
