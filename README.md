# PillarMenPrototype. Task for SquareDino

task:https://drive.google.com/file/d/1cXMg5MACYv2m0vo50OZNKklWs9-wbYM_/view

## In Russian
### Общее описание
Тестовое задание для SquareDino. В репозитории находится Юнити-проэкт целиком. 
Необходимая сцена - единственная в проекте, Location (PillarMenPrototype\Assets\Scenes\Location.unity).
После запуска персонаж игрока располагается на первом вейпоинте, и ждет команды к началу игры - тапа по экрану. После тапа
начинается "игра" и персонаж идет к первой платформе с врагами. Движение персонажа и ракурс камеры автоматические. После старта игрок может стелять, тапая по цели. Враги 
умирают после трех попаданий, здоровье врагов, получивших урон подсвечивается. После смерти враги падают на землю рэгдолом. После зачистки персонаж отправляется к 
следующей точке. Если точка, к которой направляется игрок уже зачищена, он идет к следующей. При достижении последней точки сцена рестартится.
### Боевые "сцены"
Локация организована как последовательность сцен, где игрок должен сражаться с врагами, на тестовой локации они находятся в объекте scene, но это только для визуального
удобства. Каждая сцена состоит Общего скрипта(SceneScript), вейпоинта(waypoint), и врагов(enemies). Для работы в соответствующих полях SceneScript должны быть указаны
Enemies и Waypoint, также у всех врагов в их скрипте (EnemieScript) должна быть указана сцена, к которой они принадлежат. Всё это можно указать в инспекторе. Также можно
использовать префаб  боевой сцены, он уже настроен.
### Последовательноть вейпоинтов и её настройка
Последовательнось локаций определяется в скрипте WaypointMovement, компонент Controller внутри PlayerBox. Чтобы задать последовательность зачистки надо добавить сцены в массив
WayPoints в таком порядке, в каком их должен проходить игрок. Рекомендуется заканчивать последовательность EndScene-ой, так как уровень пререзапустится при достижении последней точки, вне зависимости от наличия на ней врагов. Также при изменении сцены надо быдет заново испечь навмеш, чтобы игром мог нормально передвигаться.
### Стрельба и враги
За стрельбу отвечают скрипты Pooler и Shooting на том же компоненте Controller. Пулер создает пул снарядов, которые используются для стрельбы. Используемый префаб, размер пула
и скорость снарядов задаются в нем же через инспектор. Shooting отвечает за место, где спавнится снаряд и за слои, по которым можно выстрелить. Сцену также окружет куб из
невидимых коллайдеров, чтобы можно было выстрелить в любую точку. У врагов можно настроить максимальное хп, и силу, прилагаемую к рэгдолу в момент смерти. Урон, наносимый стрельбой, настраивается в префабе снаряда

### Создание своих сцен
Таким образом, для создания новой сцены необходимо: Создать ландшафт, сделать его статичным для навмеша, запечь навмеш. Добавить невидимый куб вокруг сцены для стрельбы
(есть префаб). Расположить префабы боевых сцен, старт-сцены и конечной сцены, добавить или удалить врагов по вкусу (Копированием уже имеющихся в префабе врагов или 
добавлением новых через отдельный префаб, но во втором случае надо не забывать про настройку). Добавить плейрбокс, поместить в массив WayPoints сцены в желаемом порядке. 
??? 
Profit. 

### Потраченное время 
~1ч Начало: Знакомство с референсом, создание проекта и репозитория git
~1ч Продумывание архитектуры
~4ч Стрельба и расстреливание врагов, в том числе ~1ч на пул
~3ч Ходьба по вейпоинтам, тап ту старт, рестарт уровня
~3ч Анимации
~0.5ч Камера
~1ч Общая сборка
~1.5ч Ревью кода
~1ч Хелсбар
~3ч Рэгдол
~2ч Сетап итоговой сцены
~3ч Тестинг, фикс мелких багов, мелкий тюн
~1.5ч Описание и документация

### Материалы и источники
Анимация - mixamo.com
POLYGON Starter Pack - https://assetstore.unity.com/packages/3d/props/polygon-starter-pack-low-poly-3d-art-by-synty-156819
