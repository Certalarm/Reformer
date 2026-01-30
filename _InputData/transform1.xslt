<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:output method="xml" indent="yes"/>

	<xsl:template match="/Pay">
		<Employees>
			<xsl:for-each select="item[generate-id() = generate-id(key('employee', concat(@name,'|',@surname))[1])]">
				<Employee name="{@name}" surname="{@surname}">
					<xsl:apply-templates select="key('employee', concat(@name,'|',@surname))"/>
				</Employee>
			</xsl:for-each>
		</Employees>
	</xsl:template>

	<xsl:template match="item">
		<salary amount="{translate(@amount,',','.')}" mount="{@mount}"/>
	</xsl:template>

	<xsl:key name="employee" match="item" use="concat(@name,'|',@surname)" />

</xsl:stylesheet>