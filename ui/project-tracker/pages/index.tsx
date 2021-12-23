import type { NextPage } from 'next'
import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'
import useSWR from 'swr'

const fetcher = (url: string) => fetch(url).then((res) => res.text())

const Home: NextPage = () => {
    
    // TODO: use some dev env switch
    const { data, error } = useSWR(process.env.NEXT_PUBLIC_API_BASE_URI + '/projects', fetcher)
    
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
          {error && <p> {JSON.stringify(error)} </p>}

          {data && <p>{data}</p>}
        
      </main>

      {/*<footer className={styles.footer}>*/}
      {/*</footer>*/}
    </div>
  )
}

export default Home
