<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:output method="xml" indent="yes"/>

	<xsl:template match="/">
		<Employees>
			<xsl:for-each select="//item">
				<xsl:if test="not(preceding::item[@name = current()/@name and @surname = current()/@surname])">
					<Employee name="{@name}" surname="{@surname}">
						<xsl:apply-templates select="//item[@name = current()/@name and @surname = current()/@surname]" mode="salary"/>
					</Employee>
				</xsl:if>
			</xsl:for-each>
		</Employees>
	</xsl:template>

	<xsl:template match="item" mode="salary">
		<salary amount="{translate(@amount,',','.')}" mount="{name(..)}" />
	</xsl:template>

</xsl:stylesheet>