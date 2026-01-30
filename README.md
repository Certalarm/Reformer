# ТЗ
- **`TASK-1.`** Написать xslt-преобразование, которое на основе входящего файла Data1.xml или Data2.xml построит файл Employees.xml

- **`TASK-2.`** Написать программу на языке `C#`, которая: 
1)	Запускает xslt-преобразование, написанное в задании 1.
2)	После xslt-преобразования, дописывает в элемент Employee атрибут, который отражает сумму всех amount/@salary этого элемента
3)	В исходный файл Data1.xml в элемент Pay дописывает атрибут, который отражает сумму всех amount
4)	Имеет GUI с кнопкой запуска программы и отображением списка всех Employee и сумму всех выплат (amount) по месяцам (mount).
5)	`*` (НЕ ОБЯЗАТЕЛЬНЫЙ ПУНКТ) Реализовать добавление в файл Data1.xml данных для строки item с возможность пересчета всех данных (с 1 по 4 пункты).

`*` Если решение тестового задания предоставляется в виде ссылки на репозиторий, то дополнительным плюсом будет отражение истории изменений по проекту (то есть лучше если будет несколько коммитов с отражением поэтапной работы над решением, а не просто залитый готовый проект).

## РЕШЕНИЕ
### `TASK-1`
Xslt-преобразование:
```xml
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:output method="xml" indent="yes"/>

	<xsl:template match="/">
		<Employees>
			<xsl:choose>
				<!--(формат Data1.xml)--> 
				<xsl:when test="./Pay/item">
					<xsl:apply-templates select="Pay" />
				</xsl:when>

				<!--(формат Data2.xml)--> 
				<xsl:otherwise>
					<xsl:apply-templates select="Pay" mode="month-group"/>
				</xsl:otherwise>
			</xsl:choose>
		</Employees>
	</xsl:template>

	<xsl:template match="/Pay">
		<xsl:for-each select="item[generate-id() = generate-id(key('employee', concat(@name,'|',@surname))[1])]">
			<Employee name="{@name}" surname="{@surname}">
				<xsl:apply-templates select="key('employee', concat(@name,'|',@surname))"/>
			</Employee>
		</xsl:for-each>
	</xsl:template>

	<xsl:template match="/Pay" mode="month-group">
		<xsl:for-each select="//item">
			<xsl:if test="not(preceding::item[@name = current()/@name and @surname = current()/@surname])">
				<Employee name="{@name}" surname="{@surname}">
					<xsl:apply-templates select="//item[@name = current()/@name and @surname = current()/@surname]" mode="month-group"/>
				</Employee>
			</xsl:if>
		</xsl:for-each>
	</xsl:template>

	<xsl:template match="item">
		<salary amount="{@amount}" mount="{@mount}"/>
	</xsl:template>

	<xsl:template match="item" mode="month-group">
		<salary amount="{@amount}" mount="{name(..)}" />
	</xsl:template>

	<xsl:key name="employee" match="item" use="concat(@name,'|',@surname)" />

</xsl:stylesheet>
```

Сам файл `trnsform.xslt` [здесь](https://github.com/Certalarm/Reformer/blob/dev/_InputData/transform.xslt).
Также есть файлы решения задачи по шагам. Для `Data1.xml` [здесь](https://github.com/Certalarm/Reformer/blob/dev/_InputData/transform1.xslt). Для `Data2.xml` [здесь](https://github.com/Certalarm/Reformer/blob/dev/_InputData/transform2.xslt).

### `TASK-2`

