pipeline {
  agent any
  stages {
    stage('Buzz Build') {
      steps {
        echo 'hello world'
      }
    }

    stage('Buzz Test') {
      steps {
        sh './jenkins/test-all.sh'
      }
    }

  }
}