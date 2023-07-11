using Bestemmiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bestemmiator.Grammar
{
    class Generator
    {
        private Random rand;
        private Node<Catalog> maleSubjects;
        private Node<Catalog> femaleSubjects;
        private Node<Catalog> genericAttributes;
        private Node<Catalog> femaleAttributes;
        private Node<Catalog> simpleConjunctions;
        private Node<Catalog> verbs;
        private Node<Catalog> maleConnections;
        private Node<Catalog> femaleConnections;

        public Generator()
        {
            rand               = new Random(666);
            maleSubjects       = new Node<Catalog>(false);
            femaleSubjects     = new Node<Catalog>(false);
            genericAttributes  = new Node<Catalog>(true);
            femaleAttributes   = new Node<Catalog>(true);
            simpleConjunctions = new Node<Catalog>(false);
            verbs              = new Node<Catalog>(true);
            maleConnections    = new Node<Catalog>(false);
            femaleConnections  = new Node<Catalog>(false);




            maleSubjects.Add(genericAttributes      , 1.0f);
            
            femaleSubjects.Add(femaleAttributes     , 0.5f);
            femaleSubjects.Add(genericAttributes    , 0.5f);


            genericAttributes.Add(genericAttributes , 0.2f);
            genericAttributes.Add(simpleConjunctions, 0.8f);

            femaleAttributes.Add(femaleAttributes   , 0.5f);
            femaleAttributes.Add(simpleConjunctions , 0.5f);

            simpleConjunctions.Add(verbs            , 1.0f);

            verbs.Add(maleConnections               , 0.5f);
            verbs.Add(femaleConnections             , 0.5f);

            maleConnections.Add(maleSubjects        , 1.0f);
            femaleConnections.Add(femaleSubjects    , 1.0f);

            #region data

            maleSubjects.Value.Add(new Subject("Dio", Gender.Male));
            maleSubjects.Value.Add(new Subject("Gesù", Gender.Male));
            maleSubjects.Value.Add(new Subject("Cristo", Gender.Male));
            maleSubjects.Value.Add(new Subject("Papa Francesco", Gender.Male));
            maleSubjects.Value.Add(new Subject("Ratzingher", Gender.Male));
            maleSubjects.Value.Add(new Subject("San Giuseppe", Gender.Male));
            maleSubjects.Value.Add(new Subject("Giovanni Apostolo", Gender.Male));
            maleSubjects.Value.Shuffle();

            femaleSubjects.Value.Add(new Subject("Madonna", Gender.Female));
            femaleSubjects.Value.Add(new Subject("Maria", Gender.Female));
            femaleSubjects.Value.Add(new Subject("Maria Maddalena", Gender.Female));
            femaleSubjects.Value.Add(new Subject("Santa Domitilla", Gender.Female));

            femaleSubjects.Value.Shuffle();


            genericAttributes.Value.Add(new SubjectAttribute("maledett@"));
            genericAttributes.Value.Add(new SubjectAttribute("porc@"));
            genericAttributes.Value.Add(new SubjectAttribute("dannat@"));
            genericAttributes.Value.Add(new SubjectAttribute("impestat@"));
            genericAttributes.Value.Add(new SubjectAttribute("capovolt@"));
            genericAttributes.Value.Add(new SubjectAttribute("bastard@"));
            genericAttributes.Value.Add(new SubjectAttribute("signor@ del cazzo"));
            genericAttributes.Value.Add(new SubjectAttribute("patron@ della merda"));
            genericAttributes.Value.Add(new SubjectAttribute("figli@ di satana"));
            genericAttributes.Value.Add(new SubjectAttribute("sudat@"));
            genericAttributes.Value.Add(new SubjectAttribute("profug@ giude@"));
            genericAttributes.Value.Add(new SubjectAttribute("vagabond@"));
            genericAttributes.Value.Add(new SubjectAttribute("sporc@"));
            genericAttributes.Value.Shuffle();

            femaleAttributes.Value.Add(new SubjectAttribute("mestruata"));
            femaleAttributes.Value.Add(new SubjectAttribute("stuprata"));
            femaleAttributes.Value.Add(new SubjectAttribute("infoiata"));
            femaleAttributes.Value.Add(new SubjectAttribute("logora"));
            femaleAttributes.Value.Add(new SubjectAttribute("concupita"));
            femaleAttributes.Value.Add(new SubjectAttribute("tanto porca quanto puttana"));      //Farlo apparire una sola volta (reusable for subject attributes)      
            femaleAttributes.Value.Shuffle();

            simpleConjunctions.Value.Add(new Conjunction("che"));
            simpleConjunctions.Value.Add(new Conjunction("mentre"));
            simpleConjunctions.Value.Add(new Conjunction("quando"));
            simpleConjunctions.Value.Shuffle();

            //il clero
            
            verbs.Value.Add(new VerbAndObjects("suona", "L'organetto", "il flauto", "il basso", "la tromba", "la fisarmonica", "il violino", "il tamburo"));
            verbs.Value.Add(new VerbAndObjects("ingoia", "un rospo", "una salsiccia", "una pigna", "un vibratore", "la bibbia", "i vangeli"));
            verbs.Value.Add(new VerbAndObjects("mangia", "del letame", "la merda", "i resti di cristo"));
            verbs.Value.Add(new VerbAndObjects("bestemmia", "maria vergine", "gesù bambino", "il clero", "san giuseppe"));
            verbs.Value.Add(new VerbAndObjects("implora", "il demonio", "per il martirio dei santi", "l'olocausto nucleare"));
            verbs.Value.Add(new VerbAndObjects("recita", "il vangelo", "il rosario", "il padre nostro", "l'ave maria"));
            verbs.Value.Add(new VerbAndObjects("confuta", "l'esistenza di dio", "il decoro dei martiri", "la verginità di maria", "l'esistenza dello spirito santo"));
            verbs.Value.Add(new VerbAndObjects("piange", "la condizione umana", "il declino della chiesa", "la caduta dell'impero romano", "la crocefissione di cristo"));
            verbs.Value.Add(new VerbAndObjects("esprime", "il malcontento del clero", "rabbia per verso la diocesi", "gioia per la morte del papa", "il disappunto dei santi"));
            verbs.Value.Add(new VerbAndObjects("nuota", "nella merda", "nella vasca da bagno", "nelle fogne di roma"));
            verbs.Value.Add(new VerbAndObjects("affoga", "in fondo al mediterraneo", "nel tevere sotto gli occhi di tutti i santi gaudienti"));
            verbs.Value.Add(new VerbAndObjects("si ficca", "una vongola nel culo", "un bastone in bocca", "un petardo nel culo"));
            verbs.Value.Add(new VerbAndObjects("picchia", "la testa sui coglioni di dio", "le palle sull'altare durante la messa", "la salma di cristo nel sepolcro"));

            //Test Passive
            verbs.Value.Add(new VerbAndObjects("viene infilzat@ alle costole", "con una lancia da un legionario romano", "dal clero urlante", "dai giannizzeri ottomani"));
            verbs.Value.Add(new VerbAndObjects("viene pres@ a", "sassate in faccia dai negri", "schiaffi sul culo dalla mano di dio", "calci nel culo"));


            verbs.Value.Shuffle();

            maleConnections.Value.Add(new Conjunction("e"));
            maleConnections.Value.Add(new Conjunction("insieme a"));
            maleConnections.Value.Add(new Conjunction("con"));
            maleConnections.Value.Shuffle();

            femaleConnections.Value.Add(new Conjunction("e"));
            femaleConnections.Value.Add(new Conjunction("insieme alla"));
            femaleConnections.Value.Add(new Conjunction("con la"));
            femaleConnections.Value.Shuffle();


            #endregion
        }

        public string Get(int level) => this.GetElements(level).Select(x => x.Text).Aggregate((x, y) => x + " " + y);

        public IEnumerable<Element> GetElements(int level)
        {
            Node<Catalog> current = rand.Next(3) <= 1 ? maleSubjects : femaleSubjects;
            List<Element> sequence = new List<Element>();

            Subject currentSubject = null;

            while (level > 0 || current.IsBreakable)
            {
                Element next = current.Value.Get();
                next.Render();

                if (next is Subject)
                {
                    currentSubject = next as Subject;
                    level--;
                }
                else if (next is GenderDependency gen)
                {
                    gen.Set(currentSubject.Gender);
                }

                sequence.Add(next);
                current = current.GetNextWeighted();
            }

            return sequence;
        }
    }
}
