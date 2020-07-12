pipeline {
  agent any
  stages {
    stage('Buzz Build') {
      steps {
        echo 'hello world'
        archiveArtifacts(artifacts: 'target/*.jar', fingerprint: true)
      }
    }

    stage('Buzz Test') {
      steps {
        sh 'which java'
      }
    }

  }
}