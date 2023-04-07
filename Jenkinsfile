node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    def msbuildHome = tool 'Default MSBuild'
    def scannerHome = tool 'SonarScanner for MSBuild'
    withSonarQubeEnv() {
      "bat ${scannerHome}SonarScanner.MSBuild.exe begin mediatekdocuments"
      "bat ${msbuildHome}MSBuild.exe tRebuild"
      "bat ${scannerHome}SonarScanner.MSBuild.exe end"
    }
  }
}
