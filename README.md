# TestMindbox
1. C# библиотекa, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.
* Юнит-тесты;
* Легкость добавления других фигур - новая фигура должна реализовывать один метод;
* Вычисление площади фигуры без знания типа фигуры в compile-time (см. [/Test/Mist.cs](https://github.com/Efaten/TestMindbox/blob/130de1df9a67e4d0987fdf6e9c1dfe69661d9b5c/Tests/Misc.cs)):
* Проверка, является ли треугольник прямоугольным (см. [Triangle.IsRightAngled](https://github.com/Efaten/TestMindbox/blob/130de1df9a67e4d0987fdf6e9c1dfe69661d9b5c/Geometry/Triangle.cs#L30)).
2. В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много
категорий, в одной категории может быть много продуктов. SQL запрос для выбора всех пар
«Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно
выводиться.
```
select p."name", c."name" from Product p 
left join ProductCategories pc on p.id == pc.pid
left join Categories c on pc.cid == c.id
```
