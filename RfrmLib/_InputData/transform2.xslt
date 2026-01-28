<!--<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:output method="xml" indent="yes"/>

	--><!-- Основная структура --><!--
	<xsl:template match="/">
		<Employees>
			--><!-- Обходим всех сотрудников в каждом месяце --><!--
			<xsl:for-each select="//item">
				--><!-- Создаем сотрудника, группируя записи по имени и фамилии --><!--
				<xsl:if test="not(preceding::item[@name = current()/@name and @surname = current()/@surname])">
					<Employee name="{@name}" surname="{@surname}">
						--><!-- Добавляем зарплаты каждого месяца --><!--
						<xsl:apply-templates select="//item[@name = current()/@name and @surname = current()/@surname]" mode="salary"/>
					</Employee>
				</xsl:if>
			</xsl:for-each>
		</Employees>
	</xsl:template>

	--><!-- Шаблон для вывода зарплат --><!--
	<xsl:template match="item" mode="salary">
		<salary amount="{translate(@amount,',','.')}" mount="{../name}"/>
	</xsl:template>
</xsl:stylesheet>-->

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" indent="yes"/>

	<!-- Главная секция -->
	<xsl:template match="/">
		<Employees>
			<!-- Обрабатываем всех сотрудников -->
			<xsl:for-each select="//item">
				<!-- Группируем по уникальным сотрудникам -->
				<xsl:if test="not(preceding::item[@name = current()/@name and @surname = current()/@surname])">
					<Employee name="{@name}" surname="{@surname}">
						<!-- Подставляем зарплаты каждого сотрудника -->
						<xsl:apply-templates select="//item[@name = current()/@name and @surname = current()/@surname]" mode="salary"/>
					</Employee>
				</xsl:if>
			</xsl:for-each>
		</Employees>
	</xsl:template>

	<!-- Шаг для добавления зарплаты -->
	<xsl:template match="item" mode="salary">
		<salary amount="{translate(@amount,',','.')}" mount="{name(..)}" />
	</xsl:template>

</xsl:stylesheet>