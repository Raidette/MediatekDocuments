node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    def msbuildHome = tool 'Default MSBuild'
    def scannerHome = tool 'SonarScanner for MSBuild'
    withSonarQubeEnv() {
      bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" begin /k:\"mediatekdocuments\""
      bat "\"${msbuildHome}\\MSBuild.exe\" /t:Restore MediaTek"
      bat "\"${msbuildHome}\\MSBuild.exe\" /t:Rebuild MediaTekDocuments.sln"
      bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" end"
    }
  }
}
