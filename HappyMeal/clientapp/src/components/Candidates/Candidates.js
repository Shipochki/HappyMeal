import { Candidate } from "./Candidate/Candidate"

export const Candidates = ({
    candidates
  }) =>{
      return (
          <section className="candidates">
            <h1>All Candidates</h1>
  
            {candidates.map(x =>
              <Candidate key={x.id} {...x}/> 
            )}
  
            {candidates.length === 0 && (
              <h3 className="no-articles">No candidates yet!</h3>
            )}
          </section>
      )
  }