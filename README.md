# Computer Configurator

## Небольшой сервис для создания конфигурации компьютера

В приложении можно сконфигурировать ПК из комплектующих интернет-магазина техники Ситилинк

Конфигуратор: [конфигуратор](http://computerconfigurator.ru/ComputerConfig)

База данных комплектующих будет обновляться каждую ночь

## Работа с api

**(в дальнейшем планируется добавление Swagger)**

На данный момент доступны запросы для получения списков комплектующих в формате JSON

http://computerconfigurator.ru/api/products/[category] where category : audiocards/coolers/casings/processors/graphics/hdd/motherboards/psu/ram/ssd/sockets

Пример: http://computerconfigurator.ru/api/products/coolers

## Технологии

``aspnet:6.0``  ``EF Core 7.0``  ``MariaDB``  ``Pomelo.EntityFrameworkCore.MySql``

``gitlab CI/CD`` - для обновления image в docker

База данных и приложение запущены на vps сервере

## Скриншоты

**Главная страница**

![plob](https://github.com/Vladosicc/ComputerConfigurator/blob/main/images/img_slide_1.png)

***

**Список процессоров**

![plob](https://github.com/Vladosicc/ComputerConfigurator/blob/main/images/img_slide_2.png)

***

**Подробные характеристики**

![plob](https://github.com/Vladosicc/ComputerConfigurator/blob/main/images/img_slide_3.png)
