import type { NextPage } from 'next'
import styles from '../styles/Home.module.css'
import useSWR from 'swr'
import { ProjectsTable } from './ProjectsTable'

let baseUri = process.env.NEXT_PUBLIC_API_BASE_URI || 'http://localhost:8080';
const fetcher = (url: string) => fetch(baseUri + url).then((res) => res.json())

const ProjectsTableLoader: NextPage = () => {
    
    const { data, error } = useSWR('/projects', fetcher)

    if(error) {
        return <p> {JSON.stringify(error)} </p>
    }
    
    if(!data) {
        return <p>loading...</p>
    }
    
    return (
        <ProjectsTable projects={data} />
    )
}

export default ProjectsTableLoader
