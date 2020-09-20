let values=[];
let w=50;
let states=[];
function setup()
{
  createCanvas(windowWidth,windowHeight);
  values = new Array(floor(width/w));
  
  for(var i=0;i<values.length;i++)
  {
      values[i]=random(height);
      states[i]=-1;
  }
  selectionSort(values);
}

async function selectionSort(values)
{
  
   for(var i=0;i<values.length-1;i++)
   {
     
     let min_idx=i;
     for(var j=i+1;j<values.length;j++)
     {
       if(values[j]<values[min_idx])
       {
         states[j]=0;
         await swap(values,min_idx,j);
         states[j]=-1;
         states[min_idx]=1;
       }
     }
    
   }
   
  
}

function draw()
{
    background('pink');

    for(var i=0;i<values.length;i++)
    {
        stroke(0);
        if(states[i]==0)
        {
           
          fill('red');
        }
      else if(states[i]==1)
              {
                fill('purple');
              }
        else
        {
            fill(255);
        }
        rect(i * w, height - values[i], w, values[i]);
    }
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

async function swap(array,p1,p2)
{

 await sleep(300);
  var temp=array[p1];
  array[p1]=array[p2];
  array[p2]=temp;
}