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
		<Employees>
			<xsl:for-each select="item[generate-id() = generate-id(key('employee', concat(@name,'|',@surname))[1])]">
				<Employee name="{@name}" surname="{@surname}">
					<xsl:apply-templates select="key('employee', concat(@name,'|',@surname))"/>
				</Employee>
			</xsl:for-each>
		</Employees>
	</xsl:template>

	<xsl:template match="/Pay" mode="month-group">
		<Employees>
			<xsl:for-each select="//item">
				<xsl:if test="not(preceding::item[@name = current()/@name and @surname = current()/@surname])">
					<Employee name="{@name}" surname="{@surname}">
						<xsl:apply-templates select="//item[@name = current()/@name and @surname = current()/@surname]" mode="month-group"/>
					</Employee>
				</xsl:if>
			</xsl:for-each>
		</Employees>
	</xsl:template>

	<xsl:template match="item">
		<salary amount="{translate(@amount,',','.')}" mount="{@mount}"/>
	</xsl:template>

	<xsl:template match="item" mode="month-group">
		<salary amount="{translate(@amount,',','.')}" mount="{name(..)}" />
	</xsl:template>

	<xsl:key name="employee" match="item" use="concat(@name,'|',@surname)" />


</xsl:stylesheet>