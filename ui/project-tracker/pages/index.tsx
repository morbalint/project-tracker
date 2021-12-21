import type { NextPage } from 'next'
import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'
import useSWR from 'swr'

const fetcher = (url: string) => fetch(url).then((res) => res.text())

const Home: NextPage = () => {
    
    // TODO: use some dev env switch
    const { data, error } = useSWR('http://localhost:8080/projects', fetcher)

    if (error) return <div>failed to load</div>
    if (!data) return <div>loading...</div>
    
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

          {!data && <p>loading...</p>}
          {error && <p> error </p>}

          {data && <p>{data}</p>}
        
      </main>

      {/*<footer className={styles.footer}>*/}
      {/*</footer>*/}
    </div>
  )
}

export default Home
