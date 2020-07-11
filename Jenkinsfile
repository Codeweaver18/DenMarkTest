pipeline {
  agent any
  stages {
    stage('Pull from Git') {
      steps {
        git(credentialsId: 'github-id', poll: true, url: 'https://github.com/Codeweaver18/DenMarkTest', branch: 'master')
      }
    }

  }
  environment {
    name = 'denmarktest'
  }
}