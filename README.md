# PillarMenPrototype. Task for SquareDino

task:https://drive.google.com/file/d/1cXMg5MACYv2m0vo50OZNKklWs9-wbYM_/view

## In Russian
Тестовое задание для SquareDino. В репозитории находится Юнити-проэкт целиком. 
Необходимая сцена - единственная в проекте, Location (PillarMenPrototype\Assets\Scenes\Location.unity).
После запуска персонаж игрока располагается на первом вейпоинте, и ждет команды к началу игры - тапа по экрану. После тапа
начинается "игра" и персонаж идет к первой платформе с врагами. Движение персонажа и ракурс камеры автоматические. После старта игрок может стелять, тапая по цели. Враги 
умирают после трех попаданий, здоровье врагов, получивших урон подсвечивается. После смерти враги падают на землю рэгдолом. После зачистки персонаж отправляется к 
следующей точке. Если точка, к которой направляется игрок уже зачищена, он идет к следующей. При достижении последней точки сцена рестартится.

Локация организована как последовательность сцен, где игрок должен сражаться с врагами, на тестовой локации они находятся в объекте scene, но это не обязательно. Каждая сцена
состоит Общего скрипта(SceneScript), вейпоинта(waypoint), и врагов(enemies). Для работы в соответствующих полях SceneScript должны быть указаны Enemies и Waypoint, также у 
всех врагов в их скрипте (EnemieScript) должна быть указана сцена, к которой они принадлежат. Всё это можно указать в инспеторе. Также можно использовать префаб  боевой сцены,
он уже настроен.

Последовательнось локаций определяется в скрипте WaypointMovement, компонент Controller внутри PlayerBox. Чтобы задать последовательность зачистки надо добавить сцены в массив
WayPoints в таком порядке, в каком их должен проходить игрок. Рекомендуется заканчивать последовательность EndScene-ой, но это не обязательно.
Также при изменении сцены надо быдет заново испечь навмеш, чтобы игром мог нормально передвигаться.

За стрельбу отвечают скрипты Pooler и Shooting на том же компоненте Controller
