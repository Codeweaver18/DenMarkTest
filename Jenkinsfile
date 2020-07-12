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
        sh 'which java'
      }
    }

    stage('deploy to production') {
      steps {
        input(message: 'deploy to production?', ok: 'yes deploy')
      }
    }

  }
}