import type { NextPage } from 'next'
import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'
import ProjectsTableLoader from '../components/ProjectsTableLoader';

const Home: NextPage = () => {
    
  return (
    <div className={styles.container}>
      <Head>
        <title>Project Tracker</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main className={styles.main}>
        <h1 className={styles.title}>
          Project Tracker
        </h1>

          <ProjectsTableLoader />
        
      </main>

      {/*<footer className={styles.footer}>*/}
      {/*</footer>*/}
    </div>
  )
}

export default Home
